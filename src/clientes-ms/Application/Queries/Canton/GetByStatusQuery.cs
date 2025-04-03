using clientes_ms.Application.Records.Response;
using MediatR;

public record GetCantonesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<CantonesResponse>>>;
