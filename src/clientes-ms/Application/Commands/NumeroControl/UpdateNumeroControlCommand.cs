using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateNumeroControlCommand(long Id, NumeroControlRequest Request) : IRequest<ApiResponse<bool>>;