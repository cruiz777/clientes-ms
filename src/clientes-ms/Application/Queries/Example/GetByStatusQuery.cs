using clientes_ms.Application.Records.Response;
using MediatR;

public record GetExamplesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ExampleResponse>>>;
