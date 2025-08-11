using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Ssccs;

public record GetAllSsccQuery : IRequest<ApiResponse<IEnumerable<SsccResponse>>>;
