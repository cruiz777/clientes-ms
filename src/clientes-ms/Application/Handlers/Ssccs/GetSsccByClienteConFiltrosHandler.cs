using AutoMapper;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GetSsccByClienteConFiltrosHandler : IRequestHandler<GetSsccByClienteConFiltrosQuery, ApiResponse<PaginationResponse<SsccResponse>>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly IMapper _mapper;

    public GetSsccByClienteConFiltrosHandler(IBaseRepository<Sscc> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PaginationResponse<SsccResponse>>> Handle(GetSsccByClienteConFiltrosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var page = request.Page <= 0 ? 1 : request.Page;
            var pageSize = request.PageSize <= 0 ? 50 : Math.Min(request.PageSize, 1000);
            var skip = (page - 1) * pageSize;

            // Crear especificación para los filtros
            var specification = new SsccByClienteSpecification(request);

            // Query base con especificación
            var query = _repository.AsQueryable()
                .Include(s => s.IdPrefijoNavigation)
                .Where(specification.Criteria)
                .AsNoTracking();

            // Si hay filtros de serial, aplicar lógica en memoria
            if (HasSerialFilters(request))
            {
                // Primero obtener todos los registros que pasan los filtros básicos
                var candidatos = await query.ToListAsync(cancellationToken);

                // Aplicar filtros de serial en memoria
                var filteredCandidatos = ApplySerialFiltersInMemory(candidatos, request);

                // Calcular totales
                var totalItems = filteredCandidatos.Count;

                // Aplicar paginación
                var pagedItems = filteredCandidatos
                    .OrderByDescending(s => s.IdSscc)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(s => _mapper.Map<SsccResponse>(s))
                    .ToList();

                var pagination = new PaginationResponse<SsccResponse>(
                    items: pagedItems,
                    page: page,
                    pageSize: pageSize,
                    totalItems: totalItems,
                    message: "SSCC filtrados y paginados correctamente"
                );

                return new ApiResponse<PaginationResponse<SsccResponse>>(
                    Id: Guid.NewGuid(),
                    Type: "PAGINATION",
                    Data: pagination,
                    Message: "SSCC encontrados correctamente",
                    Count: pagedItems.Count
                );
            }
            else
            {
                // Sin filtros de serial, consulta directa en BD
                var totalItems = await query.CountAsync(cancellationToken);

                var pagedItems = await query
                    .OrderByDescending(s => s.IdSscc)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(s => _mapper.Map<SsccResponse>(s))
                    .ToListAsync(cancellationToken);

                var pagination = new PaginationResponse<SsccResponse>(
                    items: pagedItems,
                    page: page,
                    pageSize: pageSize,
                    totalItems: totalItems,
                    message: "SSCC filtrados y paginados correctamente"
                );

                return new ApiResponse<PaginationResponse<SsccResponse>>(
                    Id: Guid.NewGuid(),
                    Type: "PAGINATION",
                    Data: pagination,
                    Message: "SSCC encontrados correctamente",
                    Count: pagedItems.Count
                );
            }
        }
        catch (Exception ex)
        {
            return ApiResponse<PaginationResponse<SsccResponse>>.Error($"Error al obtener los SSCCs con filtros: {ex.Message}");
        }
    }

    private bool HasSerialFilters(GetSsccByClienteConFiltrosQuery request)
    {
        return !string.IsNullOrWhiteSpace(request.SerialDesde) || !string.IsNullOrWhiteSpace(request.SerialHasta);
    }

    private List<Sscc> ApplySerialFiltersInMemory(List<Sscc> ssccList, GetSsccByClienteConFiltrosQuery request)
    {
        var result = ssccList.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(request.SerialDesde) && int.TryParse(request.SerialDesde, out var serialDesdeInt))
        {
            result = result.Where(s => ExtractSerialFromSscc(s) >= serialDesdeInt);
        }

        if (!string.IsNullOrWhiteSpace(request.SerialHasta) && int.TryParse(request.SerialHasta, out var serialHastaInt))
        {
            result = result.Where(s => ExtractSerialFromSscc(s) <= serialHastaInt);
        }

        return result.ToList();
    }

    private int ExtractSerialFromSscc(Sscc sscc)
    {
        if (string.IsNullOrWhiteSpace(sscc.SsccCompleto) || sscc.SsccCompleto.Length != 18 || sscc.IdPrefijoNavigation?.Codpre == null)
            return 0;

        var prefixCode = sscc.IdPrefijoNavigation.Codpre;
        var prefixLength = prefixCode.Length;

        try
        {
            return prefixLength switch
            {
                5 => int.Parse(sscc.SsccCompleto.Substring(9, 8)),   // 9 dígitos de serial
                6 => int.Parse(sscc.SsccCompleto.Substring(10, 7)),  // 8 dígitos de serial
                7 => int.Parse(sscc.SsccCompleto.Substring(11, 6)),  // 7 dígitos de serial
                8 => int.Parse(sscc.SsccCompleto.Substring(12, 5)),  // 6 dígitos de serial
                _ => 0
            };
        }
        catch
        {
            return 0;
        }
    }
}

// Especificación para encapsular la lógica de filtros
public class SsccByClienteSpecification
{
    public Expression<Func<Sscc, bool>> Criteria { get; }

    public SsccByClienteSpecification(GetSsccByClienteConFiltrosQuery request)
    {
        var predicates = new List<Expression<Func<Sscc, bool>>>();

        // Filtro obligatorio por cliente
        predicates.Add(s => s.IdCliente == request.IdCliente);

        // Filtros opcionales
        if (request.IdPrefijo.HasValue)
            predicates.Add(s => s.IdPrefijo == request.IdPrefijo.Value);

        if (!string.IsNullOrWhiteSpace(request.Busqueda))
        {
            var busqueda = request.Busqueda.Trim().ToLower();
            predicates.Add(s =>
                s.Serial.ToLower().Contains(busqueda) ||
                s.SsccCompleto.ToLower().Contains(busqueda) ||
                s.Usuario!.ToLower().Contains(busqueda));
        }

        if (!string.IsNullOrWhiteSpace(request.Empaque))
            predicates.Add(s => s.Indicador.ToString() == request.Empaque);

        if (request.Estado.HasValue)
            predicates.Add(s => s.Estado == request.Estado.Value);

        if (request.FechaDesde.HasValue)
            predicates.Add(s => s.FechaCreacion >= request.FechaDesde.Value);

        if (request.FechaHasta.HasValue)
        {
            var fechaHasta = request.FechaHasta.Value.Date.AddDays(1).AddTicks(-1);
            predicates.Add(s => s.FechaCreacion <= fechaHasta);
        }

        // Combinar todos los predicados con AND
        Criteria = CombinePredicates(predicates);
    }

    private Expression<Func<Sscc, bool>> CombinePredicates(List<Expression<Func<Sscc, bool>>> predicates)
    {
        if (!predicates.Any())
            return s => true;

        var combined = predicates.First();

        foreach (var predicate in predicates.Skip(1))
        {
            combined = CombineWithAnd(combined, predicate);
        }

        return combined;
    }

    private Expression<Func<Sscc, bool>> CombineWithAnd(
        Expression<Func<Sscc, bool>> left,
        Expression<Func<Sscc, bool>> right)
    {
        var parameter = Expression.Parameter(typeof(Sscc), "s");
        var leftBody = ReplaceParameter(left.Body, left.Parameters[0], parameter);
        var rightBody = ReplaceParameter(right.Body, right.Parameters[0], parameter);
        var combinedBody = Expression.AndAlso(leftBody, rightBody);

        return Expression.Lambda<Func<Sscc, bool>>(combinedBody, parameter);
    }

    private Expression ReplaceParameter(Expression expression, ParameterExpression oldParameter, ParameterExpression newParameter)
    {
        return new ParameterReplacer(oldParameter, newParameter).Visit(expression);
    }
}
//Parametros de la expresion del codigo para saber identificar si es un parametro 
public class ParameterReplacer : ExpressionVisitor
{
    private readonly ParameterExpression _oldParameter;
    private readonly ParameterExpression _newParameter;

    public ParameterReplacer(ParameterExpression oldParameter, ParameterExpression newParameter)
    {
        _oldParameter = oldParameter;
        _newParameter = newParameter;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return node == _oldParameter ? _newParameter : base.VisitParameter(node);
    }
}