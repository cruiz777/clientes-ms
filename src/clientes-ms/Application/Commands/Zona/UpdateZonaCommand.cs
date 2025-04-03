using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateZonaCommand(long Id, ZonaRequest Request) : IRequest<ApiResponse<bool>>;