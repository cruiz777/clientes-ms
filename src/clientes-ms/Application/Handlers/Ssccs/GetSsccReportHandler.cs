using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetSsccReportHandler : IRequestHandler<GetSsccReportQuery, ApiResponse<List<SsccResponse>>>
{
    private readonly IBaseRepository<Sscc> _repository;

    public GetSsccReportHandler(IBaseRepository<Sscc> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<List<SsccResponse>>> Handle(GetSsccReportQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = _repository.AsQueryableNoTracking();

            // Filtros
            if (request.IdPrefijo.HasValue)
                query = query.Where(s => s.IdPrefijo == request.IdPrefijo.Value);

            if (request.Estado.HasValue)
                query = query.Where(s => s.Estado == request.Estado.Value);

            if (!string.IsNullOrEmpty(request.OperadorFecha))
            {
                switch (request.OperadorFecha.ToLower())
                {
                    case "=":
                        if (request.FechaDesde.HasValue)
                            query = query.Where(s => s.FechaCreacion!.Value.Date == request.FechaDesde.Value.Date);
                        break;
                    case ">":
                        if (request.FechaDesde.HasValue)
                            query = query.Where(s => s.FechaCreacion > request.FechaDesde.Value);
                        break;
                    case "<":
                        if (request.FechaDesde.HasValue)
                            query = query.Where(s => s.FechaCreacion < request.FechaDesde.Value);
                        break;
                    case ">=":
                        if (request.FechaDesde.HasValue)
                            query = query.Where(s => s.FechaCreacion >= request.FechaDesde.Value);
                        break;
                    case "<=":
                        if (request.FechaDesde.HasValue)
                            query = query.Where(s => s.FechaCreacion <= request.FechaDesde.Value);
                        break;
                    case "entre":
                        if (request.FechaDesde.HasValue && request.FechaHasta.HasValue)
                            query = query.Where(s => s.FechaCreacion >= request.FechaDesde && s.FechaCreacion <= request.FechaHasta);
                        break;
                }
            }

            // Proyección directa (optimizada)
            var items = await query
                .OrderByDescending(s => s.IdSscc)
                .Select(s => new SsccResponse
                {
                    IdSscc = s.IdSscc,
                    IdPrefijo = s.IdPrefijo,
                    IdCliente = s.IdCliente,
                    Indicador = s.Indicador,
                    Serial = s.Serial,
                    DigitoControl = s.DigitoControl,
                    SsccCompleto = s.SsccCompleto,
                    Serie = s.Serie,
                    SecuenciaInicio = s.SecuenciaInicio,
                    SecuenciaFin = s.SecuenciaFin,
                    TotalGenerado = s.TotalGenerado,
                    ProductoCodificado = s.ProductoCodificado,
                    Estado = s.Estado,
                    Usuario = s.Usuario,
                    FechaCreacion = s.FechaCreacion
                })
                .ToListAsync(cancellationToken);

            return new ApiResponse<List<SsccResponse>>(
                Id: Guid.NewGuid(),
                Type: "REPORT",
                Data: items,
                Message: $"Se encontraron {items.Count} registros para el reporte",
                Count: items.Count
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<SsccResponse>>.Error($"Error al generar el reporte: {ex.Message}");
        }
    }
}
