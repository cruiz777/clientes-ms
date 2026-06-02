using MediatR;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    // Resumen por tipo de cliente SOLO DESAFILIADAS por año/mes
    public class GetResumenTipoClienteAnioMesDesafiliadasHandler
        : IRequestHandler<GetResumenTipoClienteAnioMesDesafiliadasQuery, ApiResponse<ResumenTipoClienteAnioMesResponse>>
    {
        private const int ESTADO_DESAFILIADA = 2;

        private readonly IBaseRepository<Clientes> _clientesRepo;
        private readonly IBaseRepository<TipoCliente> _tipoClienteRepo;

        public GetResumenTipoClienteAnioMesDesafiliadasHandler(
            IBaseRepository<Clientes> clientesRepo,
            IBaseRepository<TipoCliente> tipoClienteRepo)
        {
            _clientesRepo = clientesRepo;
            _tipoClienteRepo = tipoClienteRepo;
        }

        public async Task<ApiResponse<ResumenTipoClienteAnioMesResponse>> Handle(
            GetResumenTipoClienteAnioMesDesafiliadasQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (request.Anio < 2000 || request.Anio > 2100)
                {
                    return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                        Guid.NewGuid(),
                        "ERROR",
                        null,
                        "El año enviado no es válido."
                    );
                }

                if (request.Mes < 1 || request.Mes > 12)
                {
                    return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                        Guid.NewGuid(),
                        "ERROR",
                        null,
                        "El mes enviado no es válido."
                    );
                }

                // 1) Obtener catálogo de tipos de cliente
                var tipos = await _tipoClienteRepo.AsQueryable()
                    .AsNoTracking()
                    .Select(t => new
                    {
                        t.IdTipoCliente,
                        t.Descripcion
                    })
                    .ToListAsync(cancellationToken);

                var dicTipos = tipos.ToDictionary(
                    x => x.IdTipoCliente,
                    x => (x.Descripcion ?? string.Empty).Trim()
                );

                // 2) Fechas para filtrar por rango
                // Usamos rangos en lugar de Year/Month para evitar consultas menos eficientes.
                var inicioAnio = new DateOnly(request.Anio, 1, 1);
                var finAnio = inicioAnio.AddYears(1);

                var inicioMes = new DateOnly(request.Anio, request.Mes, 1);
                var finMes = inicioMes.AddMonths(1);

                // 3) Query base de desafiliadas
                // Importante:
                // Para año/mes sí exigimos Fecfac1 porque necesitamos saber cuándo se desafiliaron.
                var qBase = _clientesRepo.AsQueryable()
                    .AsNoTracking()
                    .Where(c =>
                        c.IdEstadoEmpresa == ESTADO_DESAFILIADA &&
                        c.Fecfac1.HasValue
                    );

                // 4) Desafiliadas acumuladas del año
                var acumuladoAnioRaw = await qBase
                    .Where(c =>
                        c.Fecfac1 >= inicioAnio &&
                        c.Fecfac1 < finAnio
                    )
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new
                    {
                        IdTipoCliente = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToListAsync(cancellationToken);

                // 5) Desafiliadas del mes seleccionado
                var acumuladoMesRaw = await qBase
                    .Where(c =>
                        c.Fecfac1 >= inicioMes &&
                        c.Fecfac1 < finMes
                    )
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new
                    {
                        IdTipoCliente = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToListAsync(cancellationToken);

                // 6) Mapear resultado del año
                var acumuladoAnio = acumuladoAnioRaw
                    .OrderBy(x => x.IdTipoCliente)
                    .Select(x => new TipoClienteConteoResponse(
                        x.IdTipoCliente,
                        x.IdTipoCliente.HasValue && dicTipos.ContainsKey(x.IdTipoCliente.Value)
                            ? dicTipos[x.IdTipoCliente.Value]
                            : "SIN TIPO",
                        x.Cantidad
                    ))
                    .ToList();

                // 7) Mapear resultado del mes
                var acumuladoMes = acumuladoMesRaw
                    .OrderBy(x => x.IdTipoCliente)
                    .Select(x => new TipoClienteConteoResponse(
                        x.IdTipoCliente,
                        x.IdTipoCliente.HasValue && dicTipos.ContainsKey(x.IdTipoCliente.Value)
                            ? dicTipos[x.IdTipoCliente.Value]
                            : "SIN TIPO",
                        x.Cantidad
                    ))
                    .ToList();

                // 8) Diagnóstico requerido por ResumenTipoClienteAnioMesResponse
                var totalAnio = acumuladoAnio.Sum(x => x.Cantidad);
                var totalMes = acumuladoMes.Sum(x => x.Cantidad);

                var diagnostico = new ResumenTipoClienteDiagnostico(
                    totalAnio,
                    totalMes
                );

                // 9) Response final
                var data = new ResumenTipoClienteAnioMesResponse(
                    request.Anio,
                    request.Mes,
                    acumuladoAnio,
                    acumuladoMes,
                    diagnostico
                );

                return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                    Guid.NewGuid(),
                    "OBJECT",
                    data,
                    "Resumen año/mes DESAFILIADAS por tipo de cliente obtenido correctamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Error al obtener resumen año/mes desafiliadas: {ex.Message}"
                );
            }
        }
    }
}