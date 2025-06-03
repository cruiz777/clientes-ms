using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Gln
{
    public record GetGlnByPrefijoIdQuery(long IdPrefijos) : IRequest<ApiResponse<GlnResponse>>;
}
