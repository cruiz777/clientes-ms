using clientes_ms.Application.Records.Response;
using MediatR;
using MicroservicesTemplate.Domain;

namespace clientes_ms.Application.Queries.Sscc;

public class GetSsccByIdPrefijoNQuery : IRequest<ApiResponse<List<SsccResponse>>>
{
    public long IdPrefijo { get; set; }

    public GetSsccByIdPrefijoNQuery(long idPrefijo)
    {
        IdPrefijo = idPrefijo;
    }
}
