using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, ApiResponse<SectorResponse>>
{
    private readonly IBaseRepository<Sector> _repository;
    public GetSectorByIdHandler(IBaseRepository<Sector> repository) => _repository = repository;

    public async Task<ApiResponse<SectorResponse>> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<SectorResponse>(Guid.NewGuid(), "OBJECT", null, $"Sector with ID {request.Id} not found.");
            return new ApiResponse<SectorResponse>(Guid.NewGuid(), "OBJECT", new SectorResponse(e.IdSector, e.Descripcion?.Trim() ?? string.Empty), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<SectorResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}