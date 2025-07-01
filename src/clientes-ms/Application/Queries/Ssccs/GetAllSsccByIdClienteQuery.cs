using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Ssccs
{
    public record GetAllSsccByIdClienteQuery(
        long IdCliente,
        int Page,
        int PageSize
    ) : IRequest<ApiResponse<PaginationResponse<SsccResponse>>>;
}
