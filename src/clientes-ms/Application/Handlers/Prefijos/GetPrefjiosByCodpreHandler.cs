using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetPrefijosByCodpreHandler : IRequestHandler<GetPefijosByCodpreQuery, ApiResponse<IEnumerable<PrefijosResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public GetPrefijosByCodpreHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<PrefijosResponse>>> Handle(GetPefijosByCodpreQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var prefijos = await _repository
                .AsQueryable()
                .Where(e => e.Codpre != null && e.Codpre.ToLower().Contains(request.Codpre.ToLower()))
                .ToListAsync(cancellationToken);

            var result = prefijos.Select(entity => new PrefijosResponse
            {
                IdPrefijos = entity.IdPrefijos,
                Codpre  = entity.Codpre ?? string.Empty,
                ClientesCodigo = entity.ClientesCodigo??0
            }).ToList();

            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} cliente(s) con coincidencia de Prefijo.",
                result.Count);
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijosResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al buscar clientes por RUC: {ex.Message}");
        }
    }
}
