using clientes_ms.Application.Records.Response;
using MediatR;

public record GetSectorByIdQuery(long Id) : IRequest<ApiResponse<SectorResponse>>;
