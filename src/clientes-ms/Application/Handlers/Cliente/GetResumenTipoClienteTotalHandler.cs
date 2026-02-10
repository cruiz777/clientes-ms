using MediatR;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    // ✅ NUEVO: Resumen por tipo de cliente SIN FILTRO (total histórico)
    public class GetResumenTipoClienteTotalHandler
        : IRequestHandler<GetResumenTipoClienteTotalQuery, ApiResponse<ResumenTipoClienteTotalResponse>>
    {
        private readonly IBaseRepository<Clientes> _clientesRepo;
        private readonly IBaseRepository<TipoCliente> _tipoClienteRepo;

        public GetResumenTipoClienteTotalHandler(
            IBaseRepository<Clientes> clientesRepo,
            IBaseRepository<TipoCliente> tipoClienteRepo)
        {
            _clientesRepo = clientesRepo;
            _tipoClienteRepo = tipoClienteRepo;
        }

        public async Task<ApiResponse<ResumenTipoClienteTotalResponse>> Handle(
            GetResumenTipoClienteTotalQuery request,
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

                // 2) Total histórico (sin filtro)
                var total = await _clientesRepo.AsQueryable()
                    .AsNoTracking()
                    .CountAsync(cancellationToken);

                // 3) Conteo por tipo (sin filtro)
                var conteo = await _clientesRepo.AsQueryable()
                    .AsNoTracking()
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
                    "Resumen TOTAL por tipo de cliente obtenido correctamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<ResumenTipoClienteTotalResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Error al obtener resumen total: {ex.Message}"
                );
            }
        }
    }
}
