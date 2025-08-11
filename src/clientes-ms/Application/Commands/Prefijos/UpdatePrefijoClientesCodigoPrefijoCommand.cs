using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public class UpdatePrefijoClientesCodigoPrefijoCommand : IRequest<ApiResponse<bool>>
{
    public long IdPrefijos { get; set; }
    public long ClientesCodigo { get; set; }

    public UpdatePrefijoClientesCodigoPrefijoCommand(long idPrefijos, long clientesCodigo)
    {
        IdPrefijos = idPrefijos;
        ClientesCodigo = clientesCodigo;
    }
}
