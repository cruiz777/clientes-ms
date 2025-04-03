using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateSectorCommand(long Id, SectorRequest Request) : IRequest<ApiResponse<bool>>;