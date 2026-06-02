using MediatR;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    // ✅ NUEVO: Resumen por tipo de cliente SOLO DESAFILIADAS (id_estado_empresa = 2)
    // IMPORTANTE:
    // - Registros antiguos pueden tener Fecfac1 = NULL.
    // - Por eso, para el TOTAL histórico NO se filtra por Fecfac1.
    public class GetResumenTipoClienteTotalDesafiliadasHandler
        : IRequestHandler<GetResumenTipoClienteTotalDesafiliadasQuery, ApiResponse<ResumenTipoClienteTotalResponse>>
    {
        private const int ESTADO_DESAFILIADA = 2;

        private readonly IBaseRepository<Clientes> _clientesRepo;
        private readonly IBaseRepository<TipoCliente> _tipoClienteRepo;

        public GetResumenTipoClienteTotalDesafiliadasHandler(
            IBaseRepository<Clientes> clientesRepo,
            IBaseRepository<TipoCliente> tipoClienteRepo)
        {
            _clientesRepo = clientesRepo;
            _tipoClienteRepo = tipoClienteRepo;
        }

        public async Task<ApiResponse<ResumenTipoClienteTotalResponse>> Handle(
            GetResumenTipoClienteTotalDesafiliadasQuery request,
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

                // 2) Query base DESAFILIADAS
                // OJO: No filtrar por Fecfac1, porque hay desafiliadas antiguas con Fecfac1 = NULL.
                var qDesafiliadas = _clientesRepo.AsQueryable()
                    .AsNoTracking()
                    .Where(c => c.IdEstadoEmpresa == ESTADO_DESAFILIADA);

                // 3) Total histórico SOLO desafiliadas
                var total = await qDesafiliadas.CountAsync(cancellationToken);

                // 4) Conteo por tipo SOLO desafiliadas
                var conteo = await qDesafiliadas
                    .GroupBy(c => c.IdTipoCliente)
                    .Select(g => new
                    {
                        IdTipoCliente = g.Key,
                        Cantidad = g.Count()
                    })
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
                    "Resumen TOTAL (DESAFILIADAS) por tipo de cliente obtenido correctamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResumenTipoClienteTotalResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Error al obtener resumen total desafiliadas: {ex.Message}"
                );
            }
        }
    }
}