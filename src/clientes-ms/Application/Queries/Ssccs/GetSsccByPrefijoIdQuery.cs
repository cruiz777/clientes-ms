using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Ssccs;

public record GetSsccByPrefijoQuery(
    long IdPrefijo,
    int Page,
    int PageSize
) : IRequest<ApiResponse<PaginationResponse<SsccResponse>>>;
