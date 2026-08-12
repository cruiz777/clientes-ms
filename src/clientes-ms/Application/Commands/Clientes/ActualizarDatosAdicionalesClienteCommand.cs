using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Clientes
{
    public record ActualizarDatosAdicionalesClienteCommand(
        ActualizarDatosAdicionalesClienteRequest Request
    ) : IRequest<ApiResponse<bool>>;
}