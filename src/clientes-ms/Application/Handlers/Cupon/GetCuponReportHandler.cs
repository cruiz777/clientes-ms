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

                // DEBUG: Contar registros iniciales
                var totalInicial = await query.CountAsync(cancellationToken);
                Console.WriteLine($"📊 Total de cupones en BD: {totalInicial}");

                // Filtros simples
                if (request.IdPrefijo.HasValue)
                {
                    Console.WriteLine($"🔍 Aplicando filtro IdPrefijo: {request.IdPrefijo.Value}");
                    query = query.Where(c => c.IdPrefijo == request.IdPrefijo.Value);
                    var countDespuesPrefijo = await query.CountAsync(cancellationToken);
                    Console.WriteLine($"📊 Cupones después de filtro IdPrefijo: {countDespuesPrefijo}");
                }

                if (request.Estado.HasValue)
                {
                    Console.WriteLine($"🔍 Aplicando filtro Estado: {request.Estado.Value}");
                    query = query.Where(c => c.Estado == request.Estado.Value);
                    var countDespuesEstado = await query.CountAsync(cancellationToken);
                    Console.WriteLine($"📊 Cupones después de filtro Estado: {countDespuesEstado}");
                }

                // Filtro por fechas
                if (!string.IsNullOrEmpty(request.OperadorFecha))
                {
                    var operador = request.OperadorFecha.ToLower();
                    var operadoresValidos = new[] { "=", ">", "<", ">=", "<=", "entre" };

                    if (!operadoresValidos.Contains(operador))
                    {
                        return ApiResponse<List<CuponResponse>>.Error($"Operador de fecha inválido: '{request.OperadorFecha}'. Operadores válidos: {string.Join(", ", operadoresValidos)}");
                    }

                    // Si no se proporciona fechaDesde, usar la fecha actual por defecto
                    var fechaDesde = request.FechaDesde?.Date ?? DateTime.Now.Date;
                    var fechaHasta = request.FechaHasta?.Date ?? DateTime.Now.Date;

                    Console.WriteLine($"📅 FechaDesde calculada: {fechaDesde:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"📅 FechaHasta calculada: {fechaHasta:yyyy-MM-dd HH:mm:ss}");
                    Console.WriteLine($"🔧 Operador: {operador}");

                    // DEBUG: Ver algunas fechas de creación de los cupones
                    var sampleFechas = await query
                        .Where(c => c.FechaCreacion != null)
                        .Select(c => c.FechaCreacion)
                        .Take(5)
                        .ToListAsync(cancellationToken);

                    Console.WriteLine($"📅 Muestra de fechas en BD:");
                    foreach (var fecha in sampleFechas)
                    {
                        Console.WriteLine($"   - {fecha:yyyy-MM-dd HH:mm:ss}");
                    }

                    switch (operador)
                    {
                        case "=":
                            var fechaInicioDay = fechaDesde;
                            var fechaFinDay = fechaDesde.AddDays(1).AddTicks(-1);
                            Console.WriteLine($"🔍 Filtro = : Entre {fechaInicioDay:yyyy-MM-dd HH:mm:ss} y {fechaFinDay:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion >= fechaInicioDay &&
                                                   c.FechaCreacion <= fechaFinDay);
                            break;
                        case ">":
                            var fechaLimite = fechaDesde.AddDays(1).AddTicks(-1);
                            Console.WriteLine($"🔍 Filtro > : Mayor que {fechaLimite:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion > fechaLimite);
                            break;
                        case "<":
                            Console.WriteLine($"🔍 Filtro < : Menor que {fechaDesde:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion < fechaDesde);
                            break;
                        case ">=":
                            Console.WriteLine($"🔍 Filtro >= : Mayor o igual que {fechaDesde:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion >= fechaDesde);
                            break;
                        case "<=":
                            var fechaFin = fechaDesde.AddDays(1).AddTicks(-1);
                            Console.WriteLine($"🔍 Filtro <= : Menor o igual que {fechaFin:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion <= fechaFin);
                            break;
                        case "entre":
                            var fechaHastaFin = fechaHasta.AddDays(1).AddTicks(-1);
                            Console.WriteLine($"🔍 Filtro entre: {fechaDesde:yyyy-MM-dd HH:mm:ss} y {fechaHastaFin:yyyy-MM-dd HH:mm:ss}");
                            query = query.Where(c => c.FechaCreacion != null &&
                                                   c.FechaCreacion >= fechaDesde &&
                                                   c.FechaCreacion <= fechaHastaFin);
                            break;
                    }

                    // DEBUG: Contar después del filtro de fecha
                    var countDespuesFecha = await query.CountAsync(cancellationToken);
                    Console.WriteLine($"📊 Cupones después de filtro de fecha: {countDespuesFecha}");
                }

                // DEBUG: Query SQL final
                var sqlQuery = query.ToQueryString();
                Console.WriteLine($"🔍 SQL Query: {sqlQuery}");

                var items = await query
                    .OrderBy(c => c.IdCupon)
                    .Select(c => new CuponResponse
                    {
                        IdCupon = c.IdCupon,
                        CodigoCupon = c.CodigoCupon ?? string.Empty,
                        IdCliente = c.IdCliente,
                        IdPrefijo = c.IdPrefijo,
                        Serial = c.Serial,
                        FechaInicio = c.FechaInicio,
                        FechaCaducidad = c.FechaCaducidad,
                        FechaCreacion = c.FechaCreacion,
                        Estado = c.Estado,
                        IdGrupoProducto = c.IdGrupoProducto,
                        Descripcion = c.Descripcion,
                        IdUsuario = c.IdUsuario
                    })
                    .ToListAsync(cancellationToken);

                Console.WriteLine($"✅ Resultado final: {items.Count} cupones encontrados");

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
                Console.WriteLine($"❌ Error en handler: {ex.Message}");
                Console.WriteLine($"❌ StackTrace: {ex.StackTrace}");
                return ApiResponse<List<CuponResponse>>.Error($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}