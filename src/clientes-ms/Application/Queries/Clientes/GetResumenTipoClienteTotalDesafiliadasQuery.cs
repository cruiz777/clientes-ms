using MediatR;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class GetResumenTipoClienteTotalDesafiliadasQuery
        : IRequest<ApiResponse<ResumenTipoClienteTotalResponse>>
    {
    }
}