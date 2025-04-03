using clientes_ms.Application.Records.Response;
using MediatR;

public record GetCantonesByIdQuery(long Id) : IRequest<ApiResponse<CantonesResponse>>;
