using clientes_ms.Application.Records.Response;
using MediatR;

public record GetZonaByIdQuery(long Id) : IRequest<ApiResponse<ZonaResponse>>;
