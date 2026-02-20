using MediatR;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    public record GetResumenTipoClienteAnioMesAfiliadasQuery(int Anio, int Mes)
        : IRequest<ApiResponse<ResumenTipoClienteAnioMesResponse>>;
}
