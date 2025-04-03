using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateCantonesCommand(long Id, CantonesRequest Request) : IRequest<ApiResponse<bool>>;