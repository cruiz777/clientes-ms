using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.NumeroControl
{
    public record ObtenerYReservarNumeroControlQuery(long IdControl)
        : IRequest<ApiResponse<NumeroReservadoResponse>>;
}
