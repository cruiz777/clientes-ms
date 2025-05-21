using clientes_ms.Application.Records.Response;
using MediatR;

public class GetClienteDatosAdicionalesByClienteCodigoQuery : IRequest<ApiResponse<ClienteDatosAdicionalesResponse>>
{
    public long ClientesCodigo { get; set; }

    public GetClienteDatosAdicionalesByClienteCodigoQuery(long clientesCodigo)
    {
        ClientesCodigo = clientesCodigo;
    }
}
