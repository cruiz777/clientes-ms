using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.GrupoProducto;


public record SearchGrupoProductoQuery(
    string SearchTerm = "",
    int Limit = 100
) : IRequest<ApiResponse<IEnumerable<GrupoProductoResponse>>>;
