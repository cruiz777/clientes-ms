using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class GetPrefijosByCodigoClienteHandler : IRequestHandler<GetPrefijosByCodigoClienteQuery, ApiResponse<IEnumerable<PrefijosResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    private readonly IMapper _mapper;

    public GetPrefijosByCodigoClienteHandler(IBaseRepository<Prefijos> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

            var result = _mapper.Map<List<PrefijosResponse>>(prefijos);

            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} prefijos y sus GLNs para el cliente {request.ClientesCodigo}.",
                result.Count);
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al buscar prefijos por ClientesCodigo: {ex.Message}");
        }
    }
}
