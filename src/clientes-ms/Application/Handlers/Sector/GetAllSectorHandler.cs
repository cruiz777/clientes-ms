using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllSectorHandler : IRequestHandler<GetAllSectorQuery, ApiResponse<IEnumerable<SectorResponse>>>
{
    private readonly IBaseRepository<Sector> _repository;
    public GetAllSectorHandler(IBaseRepository<Sector> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<SectorResponse>>> Handle(GetAllSectorQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<SectorResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<SectorResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static SectorResponse MapToResponse(Sector e) => new(e.IdSector, e.Descripcion?.Trim() ?? string.Empty);
}