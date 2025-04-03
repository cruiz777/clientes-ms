using clientes_ms.Application.Records.Response;
using MediatR;

public record GetProvinciaByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ProvinciaResponse>>>;
