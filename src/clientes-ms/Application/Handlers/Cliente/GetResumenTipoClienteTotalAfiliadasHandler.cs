using MediatR;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    // ✅ NUEVO: Resumen por tipo de cliente SOLO AFILIADAS (id_estado_empresa = 1)
    public class GetResumenTipoClienteTotalAfiliadasHandler
        : IRequestHandler<GetResumenTipoClienteTotalAfiliadasQuery, ApiResponse<ResumenTipoClienteTotalResponse>>
    {
        private const int ESTADO_AFILIADA = 1;

        private readonly IBaseRepository<Clientes> _clientesRepo;
        private readonly IBaseRepository<TipoCliente> _tipoClienteRepo;

        public GetResumenTipoClienteTotalAfiliadasHandler(
            IBaseRepository<Clientes> clientesRepo,
            IBaseRepository<TipoCliente> tipoClienteRepo)
        {
            _clientesRepo = clientesRepo;
            _tipoClienteRepo = tipoClienteRepo;
        }

        public async Task<ApiResponse<ResumenTipoClienteTotalResponse>> Handle(
            GetResumenTipoClienteTotalAfiliadasQuery request,
            CancellationToken cancellationToken)
        {
            try
            {
                // 1) Catálogo tipos
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

                // 3) Total histórico SOLO afiliadas
                var total = await qAfiliadas.CountAsync(cancellationToken);

                // 4) Conteo por tipo SOLO afiliadas
                var conteo = await qAfiliadas
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new { IdTipoCliente = g.Key, Cantidad = g.Count() })
                    .ToListAsync(cancellationToken);

                var detalle = conteo
                    .OrderBy(x => x.IdTipoCliente)
                    .Select(x => new TipoClienteConteoResponse(
                        x.IdTipoCliente,
                        x.IdTipoCliente.HasValue && dicTipos.ContainsKey(x.IdTipoCliente.Value)
                            ? dicTipos[x.IdTipoCliente.Value]
                            : "SIN TIPO",
                        x.Cantidad
                    ))
                    .ToList();

                var data = new ResumenTipoClienteTotalResponse(
                    detalle,
                    new ResumenTipoClienteDiagnosticoTotal(total)
                );

                return new ApiResponse<ResumenTipoClienteTotalResponse>(
                    Guid.NewGuid(),
                    "LIST",
                    data,
                    "Resumen TOTAL (AFILIADAS) por tipo de cliente obtenido correctamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResumenTipoClienteTotalResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Error al obtener resumen total afiliadas: {ex.Message}"
                );
            }
        }
    }
}
