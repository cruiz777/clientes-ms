using MediatR;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    // ✅ NUEVO: Resumen por tipo SOLO AFILIADAS (id_estado_empresa = 1) por Año/Mes
    public class GetResumenTipoClienteAnioMesAfiliadasHandler
        : IRequestHandler<GetResumenTipoClienteAnioMesAfiliadasQuery, ApiResponse<ResumenTipoClienteAnioMesResponse>>
    {
        private const int ESTADO_AFILIADA = 1;

        private readonly IBaseRepository<Clientes> _clientesRepo;
        private readonly IBaseRepository<TipoCliente> _tipoClienteRepo;

        public GetResumenTipoClienteAnioMesAfiliadasHandler(
            IBaseRepository<Clientes> clientesRepo,
            IBaseRepository<TipoCliente> tipoClienteRepo)
        {
            _clientesRepo = clientesRepo;
            _tipoClienteRepo = tipoClienteRepo;
        }

        public async Task<ApiResponse<ResumenTipoClienteAnioMesResponse>> Handle(
            GetResumenTipoClienteAnioMesAfiliadasQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                int anio = request.Anio;
                int mes = request.Mes;

                if (mes < 1 || mes > 12)
                {
                    return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                        Guid.NewGuid(),
                        "ERROR",
                        null,
                        "El mes debe estar entre 1 y 12."
                    );
                }

                // 1) Catálogo de tipos
                var tipos = await _tipoClienteRepo.AsQueryable()
                    .AsNoTracking()
                    .Select(t => new { t.IdTipoCliente, t.Descripcion })
                    .ToListAsync(cancellationToken);

                var dicTipos = tipos.ToDictionary(
                    x => x.IdTipoCliente,
                    x => (x.Descripcion ?? string.Empty).Trim()
                );

                // 2) Query base AFILIADAS
                var qAfiliadas = _clientesRepo.AsQueryable()
                    .AsNoTracking()
                    .Where(c => c.IdEstadoEmpresa == ESTADO_AFILIADA);

                // Diagnóstico: totales AFILIADAS
                var totalAnio = await qAfiliadas.CountAsync(c =>
                        c.Fecing.HasValue &&
                        c.Fecing.Value.Year == anio,
                    cancellationToken);

                var totalMes = await qAfiliadas.CountAsync(c =>
                        c.Fecing.HasValue &&
                        c.Fecing.Value.Year == anio &&
                        c.Fecing.Value.Month == mes,
                    cancellationToken);

                // 3) Conteo anual AFILIADAS por IdTipoCliente
                var conteoAnual = await qAfiliadas
                    .Where(c => c.Fecing.HasValue && c.Fecing.Value.Year == anio)
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new { IdTipoCliente = g.Key, Cantidad = g.Count() })
                    .ToListAsync(cancellationToken);

                // 4) Conteo mensual AFILIADAS por IdTipoCliente
                var conteoMensual = await qAfiliadas
                    .Where(c => c.Fecing.HasValue && c.Fecing.Value.Year == anio && c.Fecing.Value.Month == mes)
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new { IdTipoCliente = g.Key, Cantidad = g.Count() })
                    .ToListAsync(cancellationToken);

                var anualResp = conteoAnual
                    .OrderBy(x => x.IdTipoCliente)
                    .Select(x => new TipoClienteConteoResponse(
                        x.IdTipoCliente,
                        x.IdTipoCliente.HasValue && dicTipos.ContainsKey(x.IdTipoCliente.Value)
                            ? dicTipos[x.IdTipoCliente.Value]
                            : "SIN TIPO",
                        x.Cantidad
                    ))
                    .ToList();

                var mensualResp = conteoMensual
                    .OrderBy(x => x.IdTipoCliente)
                    .Select(x => new TipoClienteConteoResponse(
                        x.IdTipoCliente,
                        x.IdTipoCliente.HasValue && dicTipos.ContainsKey(x.IdTipoCliente.Value)
                            ? dicTipos[x.IdTipoCliente.Value]
                            : "SIN TIPO",
                        x.Cantidad
                    ))
                    .ToList();

                var data = new ResumenTipoClienteAnioMesResponse(
                    anio,
                    mes,
                    anualResp,
                    mensualResp,
                    new ResumenTipoClienteDiagnostico(totalAnio, totalMes)
                );

                return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                    Guid.NewGuid(),
                    "LIST",
                    data,
                    "Resumen (AFILIADAS) por tipo de cliente obtenido correctamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResumenTipoClienteAnioMesResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Error al obtener resumen afiliadas: {ex.Message}"
                );
            }
        }
    }
}
