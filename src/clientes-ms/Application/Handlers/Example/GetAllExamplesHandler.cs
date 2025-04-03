using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllExampleHandler : IRequestHandler<GetAllExampleQuery, ApiResponse<IEnumerable<ExampleResponse>>>
{
    private readonly IBaseRepository<Example> _repository;
    public GetAllExampleHandler(IBaseRepository<Example> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ExampleResponse>>> Handle(GetAllExampleQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ExampleResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ExampleResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ExampleResponse MapToResponse(Example e) => new(e.Id, e.Name?.Trim() ?? string.Empty, e.Status);
}