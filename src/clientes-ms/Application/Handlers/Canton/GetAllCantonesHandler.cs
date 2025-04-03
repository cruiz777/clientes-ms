using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllCantonHandler : IRequestHandler<GetAllCantonesQuery, ApiResponse<IEnumerable<CantonesResponse>>>
{
    private readonly IBaseRepository<Cantones> _repository;
    public GetAllCantonHandler(IBaseRepository<Cantones> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<CantonesResponse>>> Handle(GetAllCantonesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<CantonesResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<CantonesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static CantonesResponse MapToResponse(Cantones e) => new(e.IdCanton, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdProvincia);
}