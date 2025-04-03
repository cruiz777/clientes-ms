using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateZonaCommand(ZonaRequest Request) : IRequest<ApiResponse<bool>>;