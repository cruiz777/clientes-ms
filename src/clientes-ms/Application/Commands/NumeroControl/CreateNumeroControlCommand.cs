using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateNumeroControlCommand(NumeroControlRequest Request) : IRequest<ApiResponse<bool>>;