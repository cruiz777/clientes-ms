using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class GetPrefijosByIdHandler : IRequestHandler<GetPrefijosByIdQuery, ApiResponse<PrefijosResponse>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    private readonly IMapper _mapper;

    public GetPrefijosByIdHandler(IBaseRepository<Prefijos> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<PrefijosResponse>> Handle(GetPrefijosByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prefijo = await _repository
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
                .FirstOrDefaultAsync(p => p.IdPrefijos == request.Id, cancellationToken);

            if (prefijo == null)
                return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "OBJECT", null, $"Prefijo con ID {request.Id} no encontrado.");

            var mapped = _mapper.Map<PrefijosResponse>(prefijo);

            return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "OBJECT", mapped, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
