using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Clientes
{
    public record GetClientesByNomcliAsyncQuery(string Nomcli) : IRequest<ApiResponse<List<ClienteSummaryResponse>>>;

}
