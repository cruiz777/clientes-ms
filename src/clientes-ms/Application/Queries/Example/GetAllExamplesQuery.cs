using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllExampleQuery : IRequest<ApiResponse<IEnumerable<ExampleResponse>>>;