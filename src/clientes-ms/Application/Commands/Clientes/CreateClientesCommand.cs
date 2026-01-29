using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    public sealed record CreateClientesCommand(ClientesRequest Request)
        : IRequest<ApiResponse<long>>;
}
