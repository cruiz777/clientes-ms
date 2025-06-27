using AutoMapper;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

            // Query base
            var query = _repository.AsQueryable()
                .Where(s => s.IdCliente == request.IdCliente)
                .AsNoTracking();

            // Filtros compatibles con EF
            query = AplicarFiltros(query, request);

            // Total luego de filtros
            var totalItems = await query.CountAsync(cancellationToken);

            // Obtener página de datos
            var pagedItems = await query
                .OrderByDescending(s => s.IdSscc)
                .Skip(skip)
                .Take(pageSize)
                .Select(s => _mapper.Map<SsccResponse>(s))
                .ToListAsync(cancellationToken);

            // Crear respuesta paginada
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
        catch (Exception ex)
        {
            return ApiResponse<PaginationResponse<SsccResponse>>.Error($"Error al obtener los SSCCs con filtros: {ex.Message}");
        }
    }

    private IQueryable<Sscc> AplicarFiltros(IQueryable<Sscc> query, GetSsccByClienteConFiltrosQuery request)
    {
        if (request.IdPrefijo.HasValue)
            query = query.Where(s => s.IdPrefijo == request.IdPrefijo.Value);

        if (!string.IsNullOrWhiteSpace(request.Busqueda))
        {
            var busqueda = request.Busqueda.Trim().ToLower();
            query = query.Where(s =>
                s.SsccCompleto.ToLower().Contains(busqueda) ||
                s.Usuario!.ToLower().Contains(busqueda));
        }

        if (!string.IsNullOrWhiteSpace(request.Empaque))
            query = query.Where(s => s.Indicador.ToString() == request.Empaque);

        if (request.Estado.HasValue)
            query = query.Where(s => s.Estado == request.Estado.Value);

        if (request.FechaDesde.HasValue)
            query = query.Where(s => s.FechaCreacion >= request.FechaDesde.Value);

        if (request.FechaHasta.HasValue)
        {
            var fechaHasta = request.FechaHasta.Value.Date.AddDays(1).AddTicks(-1);
            query = query.Where(s => s.FechaCreacion <= fechaHasta);
        }

        return query;
    }
}
