using clientes_ms.Application.Queries.Cupones;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.Cupon
{
    public class GetCuponReportHandler : IRequestHandler<GetCuponReportQuery, ApiResponse<List<CuponResponse>>>
    {
        private readonly IBaseRepository<Cupones> _repository;

        public GetCuponReportHandler(IBaseRepository<Cupones> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<CuponResponse>>> Handle(GetCuponReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _repository.AsQueryableNoTracking();

                // Filtros simples
                if (request.IdPrefijo.HasValue)
                    query = query.Where(c => c.IdPrefijo == request.IdPrefijo.Value);

                if (request.Estado.HasValue)
                    query = query.Where(c => c.Estado == request.Estado.Value);

                // Filtro por fechas
                if (!string.IsNullOrEmpty(request.OperadorFecha))
                {
                    var operador = request.OperadorFecha.ToLower();
                    var operadoresValidos = new[] { "=", ">", "<", ">=", "<=", "entre" };

                    if (!operadoresValidos.Contains(operador))
                    {
                        return ApiResponse<List<CuponResponse>>.Error($"Operador de fecha inválido: '{request.OperadorFecha}'. Operadores válidos: {string.Join(", ", operadoresValidos)}");
                    }

                    var fechaDesde = request.FechaDesde ?? DateTime.Now.Date;
                    var fechaHasta = request.FechaHasta ?? DateTime.Now.Date;

                    switch (operador)
                    {
                        case "=":
                            query = query.Where(c => c.FechaCreacion!.Value.Date == fechaDesde);
                            break;
                        case ">":
                            query = query.Where(c => c.FechaCreacion > fechaDesde);
                            break;
                        case "<":
                            query = query.Where(c => c.FechaCreacion < fechaDesde);
                            break;
                        case ">=":
                            query = query.Where(c => c.FechaCreacion >= fechaDesde);
                            break;
                        case "<=":
                            query = query.Where(c => c.FechaCreacion <= fechaDesde);
                            break;
                        case "entre":
                            query = query.Where(c =>
                                c.FechaCreacion >= fechaDesde &&
                                c.FechaCreacion <= fechaHasta);
                            break;
                    }
                }

                var items = await query
                    .OrderBy(c => c.IdCupon)
                    .Select(c => new CuponResponse
                    {
                        IdCupon = c.IdCupon,
                        IdCliente = c.IdCliente,
                        IdPrefijo = c.IdPrefijo,
                        Serial = c.Serial,
                        Descripcion = c.Descripcion,
                        FechaInicio = c.FechaInicio,
                        FechaCaducidad = c.FechaCaducidad,
                        Estado = c.Estado,
                        IdUsuario = c.IdUsuario,
                        FechaCreacion = c.FechaCreacion
                    })
                    .ToListAsync(cancellationToken);

                return new ApiResponse<List<CuponResponse>>(
                    Id: Guid.NewGuid(),
                    Type: "REPORT",
                    Data: items,
                    Message: $"Se encontraron {items.Count} cupones para el reporte",
                    Count: items.Count
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<List<CuponResponse>>.Error($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}
