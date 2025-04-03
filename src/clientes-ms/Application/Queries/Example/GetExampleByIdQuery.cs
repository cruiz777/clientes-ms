using clientes_ms.Application.Records.Response;
using MediatR;

public record GetExampleByIdQuery(long Id) : IRequest<ApiResponse<ExampleResponse>>;
