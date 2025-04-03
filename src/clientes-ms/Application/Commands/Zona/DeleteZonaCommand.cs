using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteZonaCommand(long IdZona) : IRequest<ApiResponse<bool>>;