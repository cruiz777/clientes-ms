using clientes_ms.Application.Records.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using clientes_ms.Application.Queries.Clientes;
using System;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class GetClientesPagedHandler : IRequestHandler<GetClientesPaged, ApiResponse<IEnumerable<ClientesResponse>>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private const int MaxPageSize = 40000;

        public GetClientesPagedHandler(IBaseRepository<Clientes> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetClientesPaged request, CancellationToken cancellationToken)
        {
            try
            {
                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = request.PageSize <= 0 ? 10 : Math.Min(request.PageSize, MaxPageSize);

                var baseQuery = _repository
                    .AsQueryable()
                    .AsNoTracking();

                // Filtro por búsqueda general (código, nombre, ruc)
                if (!string.IsNullOrWhiteSpace(request.BusquedaGeneral))
                {
                    var filtro = request.BusquedaGeneral.Trim().ToLower();

                    baseQuery = baseQuery.Where(e =>
                        (!string.IsNullOrEmpty(e.Nomcli) && e.Nomcli.ToLower().Contains(filtro)) ||
                        (!string.IsNullOrEmpty(e.Ruc) && e.Ruc.ToLower().Contains(filtro)) ||
                        e.ClientesCodigo.ToString().Contains(filtro)
                    );
                }

                // Filtro por prefijo exacto
                if (!string.IsNullOrWhiteSpace(request.PrefijoBusqueda))
                {
                    baseQuery = baseQuery.Where(e => e.Prefijos.Any(p => p.Codpre == request.PrefijoBusqueda));
                }

                // 1) Total sin include (más liviano)
                var totalRegistros = await baseQuery.CountAsync(cancellationToken);

                // 2) Aplica includes sólo para proyectar
                var query = baseQuery
                    .Include(e => e.Prefijos)
                    .Include(e => e.IdZonaNavigation)
                    .Include(e => e.IdEstadoEmpresaNavigation);

                // 3) Proyecta a DTO en DB + pagina
                var data = await query
                    .OrderByDescending(e => e.Fecing)
                    .ThenBy(e => e.ClientesCodigo)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(e => new ClientesResponse
                    {
                        ClientesCodigo = e.ClientesCodigo,
                        NomCli = e.Nomcli ?? string.Empty,
                        Ruc = e.Ruc ?? string.Empty,
                        Dircli = e.Dircli ?? string.Empty,
                        Fecing = e.Fecing,
                        ZonaReferencia = e.IdZonaNavigation != null ? e.IdZonaNavigation.Referencia : string.Empty,
                        EstadoNombre = e.IdEstadoEmpresaNavigation != null ? e.IdEstadoEmpresaNavigation.Nombre : string.Empty,
                        TipoCliente = e.IdTipoClienteNavigation != null ? e.IdTipoClienteNavigation.Descripcion : string.Empty,
                        GrupoEmpresa = e.IdGrupoEmpresa != null ? e.IdGrupoEmpresaNavigation.Codigo : string.Empty,
                        Representante = e.Representante ?? string.Empty,
                        Telefono = e.Telefono ?? string.Empty,
                        Prefijo = e.Prefijos != null && e.Prefijos.Any()
                                            ? string.Join("/", e.Prefijos.Select(p => p.Codpre))
                                            : string.Empty
                    })
                    .ToListAsync(cancellationToken);

                return new ApiResponse<IEnumerable<ClientesResponse>>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    data,
                    null,
                    totalRegistros
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ClientesResponse>>.Error(
                    $"Error al obtener los clientes: {ex.Message}");
            }
        }
    }
}
