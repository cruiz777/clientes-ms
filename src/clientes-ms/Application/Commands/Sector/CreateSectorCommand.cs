using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateSectorCommand(SectorRequest Request) : IRequest<ApiResponse<bool>>;