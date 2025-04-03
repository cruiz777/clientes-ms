using clientes_ms.Application.Records.Response;
using MediatR;

public record GetProvinciaByIdQuery(long Id) : IRequest<ApiResponse<ProvinciaResponse>>;
