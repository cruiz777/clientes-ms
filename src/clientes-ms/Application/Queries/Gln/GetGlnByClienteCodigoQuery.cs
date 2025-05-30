using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Gln
{
    public record GetGlnByClienteCodigoQuery(long ClientesCodigo) : IRequest<ApiResponse<IEnumerable<GlnResponse>>>;
}
