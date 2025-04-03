using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteExampleCommand(long Id) : IRequest<ApiResponse<bool>>;