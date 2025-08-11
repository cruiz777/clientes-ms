using clientes_ms.Application.Records.Response;
using MediatR;
using MicroservicesTemplate.Domain;

namespace clientes_ms.Application.Queries.Cupon;

public class GetCuponesByIdPrefijoQuery : IRequest<ApiResponse<List<CuponResponse>>>
{
    public long IdPrefijo { get; set; }

    public GetCuponesByIdPrefijoQuery(long idPrefijo)
    {
        IdPrefijo = idPrefijo;
    }
}
