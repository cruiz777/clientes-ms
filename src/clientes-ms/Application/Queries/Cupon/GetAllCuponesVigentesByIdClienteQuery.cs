using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Cupon;

public record GetAllCuponesVigentesByIdClienteQuery(
    long IdCliente,
    int Page,
    int PageSize
) : IRequest<ApiResponse<PaginationResponse<CuponResponse>>>;
