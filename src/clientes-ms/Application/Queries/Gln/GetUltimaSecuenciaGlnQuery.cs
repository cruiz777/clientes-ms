using MediatR;

namespace clientes_ms.Application.Queries.Gln
{
    public record GetUltimaSecuenciaGlnQuery(string CodigoPais, string Prefijo) : IRequest<int>;
}
