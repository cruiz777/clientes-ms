using AutoMapper;
using clientes_ms.Application.Queries.Prefijos;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetPrefijoUnitByClienteCodigoHandler 
    : IRequestHandler<GetPrefijoUnitByClienteCodigoQuery, ApiResponse<IEnumerable<PrefijoSimpleResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    private readonly IMapper _mapper;

    public GetPrefijoUnitByClienteCodigoHandler(IBaseRepository<Prefijos> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<PrefijoSimpleResponse>>> Handle(GetPrefijoUnitByClienteCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prefijos = await _repository
                .AsQueryable()
                .Where(p => p.ClientesCodigo == request.ClientesCodigo)
                .Select(p => new PrefijoSimpleResponse
                {
                    IdPrefijos = p.IdPrefijos,
                    Codpre = p.Codpre.Trim()
                })
                // .OrderBy(p => p.Codpre)
                .ToListAsync(cancellationToken);

            return new ApiResponse<IEnumerable<PrefijoSimpleResponse>>(
                Guid.NewGuid(),
                "LIST",
                prefijos,
                $"Se encontraron {prefijos.Count} prefijos únicos para el cliente {request.ClientesCodigo}.",
                prefijos.Count);
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijoSimpleResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener prefijos únicos: {ex.Message}");
        }
    }
}
