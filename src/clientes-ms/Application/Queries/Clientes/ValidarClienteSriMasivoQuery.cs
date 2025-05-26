using clientes_ms.Application.DTOs.Clientes;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Clientes
{
    public record ValidarClientesSriMasivoQuery(List<long> ClienteIds)
        : IRequest<ApiResponse<List<ClienteValidadoResultadoDTO>>>;

}
