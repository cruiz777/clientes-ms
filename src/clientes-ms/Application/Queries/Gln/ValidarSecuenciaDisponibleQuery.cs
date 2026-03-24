using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Gln;

public record ValidarSecuenciaDisponibleQuery(
    string CodigoPais,
    string Prefijo,
    int Secuencia
) : IRequest<ApiResponse<bool>>;
