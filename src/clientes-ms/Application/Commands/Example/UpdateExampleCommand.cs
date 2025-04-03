using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateExampleCommand(long Id, ExampleRequest Request) : IRequest<ApiResponse<bool>>;