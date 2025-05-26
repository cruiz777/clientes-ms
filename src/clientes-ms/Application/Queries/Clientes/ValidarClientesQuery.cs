using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Clientes
{
    public record ValidarClienteSriQuery(long ClienteId) : IRequest<ApiResponse<ClienteValidadoDTO>>;
}
