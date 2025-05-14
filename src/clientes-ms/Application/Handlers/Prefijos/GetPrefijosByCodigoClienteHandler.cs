using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetPrefijosByCodigoClienteHandler : IRequestHandler<GetPrefijosByCodigoClienteQuery, ApiResponse<IEnumerable<PrefijosResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;

    public GetPrefijosByCodigoClienteHandler(IBaseRepository<Prefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<PrefijosResponse>>> Handle(GetPrefijosByCodigoClienteQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prefijos = await _repository
                .AsQueryable()
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdEstadoEmpresaNavigation)
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdZonaNavigation)
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdGrupoProductoNavigation)
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdTipoClienteNavigation)
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdGrupoEmpresaNavigation)
                .Include(p => p.ClientesCodigoNavigation)
                    .ThenInclude(c => c.IdCiudadNavigation)
                        .ThenInclude(ci => ci.IdCantonNavigation)
                            .ThenInclude(can => can.IdProvinciaNavigation)
                .Include(p => p.Gln)
                    .ThenInclude(g => g.IdTipoLocalizacionNavigation)
                .Where(p => p.ClientesCodigo == request.ClientesCodigo)
                .ToListAsync(cancellationToken);

            var result = prefijos.SelectMany(p =>
                p.Gln.Select(g => new PrefijosResponse
                {
                    IdPrefijos = p.IdPrefijos,
                    Codpre = p.Codpre ?? string.Empty,
                    ClientesCodigo = p.ClientesCodigo ?? 0,
                    Nomcli = p.ClientesCodigoNavigation?.Nomcli ?? string.Empty,
                    Gln = g.Gln1 ?? string.Empty,
                    TipoLocalizacion = g.IdTipoLocalizacionNavigation?.Descripcion ?? string.Empty,

                    EstadoEmpresa = p.ClientesCodigoNavigation?.IdEstadoEmpresaNavigation?.Nombre ?? string.Empty,
                    Ruccli = p.ClientesCodigoNavigation?.Ruc ?? string.Empty,
                    Fecing = p.ClientesCodigoNavigation?.Fecing ?? DateOnly.MinValue,
                    Zona = p.ClientesCodigoNavigation?.IdZonaNavigation?.Referencia ?? string.Empty,
                    TipoCliente = p.ClientesCodigoNavigation?.IdTipoClienteNavigation?.Descripcion ?? string.Empty,
                    GrupoProducto = p.ClientesCodigoNavigation?.IdGrupoProductoNavigation?.Descripcion ?? string.Empty,
                    Representante = p.ClientesCodigoNavigation?.Representante ?? string.Empty,
                    GrupoEmpresa = p.ClientesCodigoNavigation?.IdGrupoEmpresaNavigation?.Nombre ?? string.Empty,

                    // Nuevos campos agregados
                    Direccion = p.ClientesCodigoNavigation?.Dircli ?? string.Empty,
                    Telefono = p.ClientesCodigoNavigation?.Telefono1 ?? string.Empty,
                    Web = p.ClientesCodigoNavigation?.Web ?? string.Empty,
                    Postal = p.ClientesCodigoNavigation?.CodigoPostal ?? string.Empty,
                    Ciudad = p.ClientesCodigoNavigation?.IdCiudadNavigation?.Nombre ?? string.Empty,
                    Canton = p.ClientesCodigoNavigation?.IdCiudadNavigation?.IdCantonNavigation?.Nombre ?? string.Empty,
                    Provincia = p.ClientesCodigoNavigation?.IdCiudadNavigation?.IdCantonNavigation?.IdProvinciaNavigation?.Nombre ?? string.Empty
                })
            ).ToList();

            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} GLNs para el cliente {request.ClientesCodigo}.",
                result.Count);
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al buscar GLNs por ClientesCodigo: {ex.Message}");
        }
    }
}
