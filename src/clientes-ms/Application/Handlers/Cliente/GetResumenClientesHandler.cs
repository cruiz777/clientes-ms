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
    public class GetResumenClientesHandler : IRequestHandler<GetClientesByResumen, ApiResponse<IEnumerable<ClientesResponse>>>
    {
        private readonly IBaseRepository<Clientes> _repository;

        public GetResumenClientesHandler(IBaseRepository<Clientes> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetClientesByResumen request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _repository.AsQueryable();

                // Filtro por búsqueda general (código, nombre, ruc)
                if (!string.IsNullOrEmpty(request.BusquedaGeneral))
                {
                    var filtro = request.BusquedaGeneral.ToLower();
                    query = query.Where(e =>
                        (!string.IsNullOrEmpty(e.Nomcli) && e.Nomcli.ToLower().Contains(filtro)) ||
                        (!string.IsNullOrEmpty(e.Ruc) && e.Ruc.Contains(filtro)) ||
                        e.ClientesCodigo.ToString().Contains(filtro)
                    );
                }

                // Filtro por prefijo exacto
                if (!string.IsNullOrEmpty(request.PrefijoBusqueda))
                {
                    query = query.Where(e => e.Prefijos.Any(p => p.Codpre == request.PrefijoBusqueda));
                }

                // Includes
                query = query.Include(e => e.Prefijos);
                query = query.Include(e => e.IdZonaNavigation);
                query = query.Include(e => e.IdEstadoEmpresaNavigation);

                // Total sin paginar
                var totalRegistros = await query.CountAsync(cancellationToken);

                // Paginación
                var clientes = await query
                    .OrderByDescending(e => e.Fecing)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);

                // Proyección al DTO
                var result = clientes.Select(e => new ClientesResponse
                {
                    ClientesCodigo = e.ClientesCodigo,
                    NomCli = e.Nomcli ?? string.Empty,
                    Ruc = e.Ruc ?? string.Empty,
                    Dircli = e.Dircli ?? string.Empty,
                    Fecing = e.Fecing,
                    ZonaReferencia = e.IdZonaNavigation?.Referencia ?? string.Empty,
                    EstadoNombre = e.IdEstadoEmpresaNavigation?.Nombre ?? string.Empty,
                    Representante = e.Representante ?? string.Empty,
                    Telefono= e.Telefono ?? string.Empty,
                    Prefijo = e.Prefijos != null && e.Prefijos.Any()
                        ? string.Join("/", e.Prefijos.Select(p => p.Codpre))
                        : string.Empty
                }).ToList();

                return new ApiResponse<IEnumerable<ClientesResponse>>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    result,
                    null,
                    totalRegistros
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ClientesResponse>>.Error($"Error al obtener los clientes: {ex.Message}");
            }
        }
    }
}
