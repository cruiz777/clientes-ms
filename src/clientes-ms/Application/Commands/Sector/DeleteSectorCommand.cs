using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteSectorCommand(long IdSector) : IRequest<ApiResponse<bool>>;