using clientes_ms.Application.Records.Response;
using MediatR;

public class UpdateGlnClientesCodigoByIdPrefijoCommand : IRequest<ApiResponse<bool>>
{
    public long IdPrefijos { get; set; }
    public long ClientesCodigo { get; set; }

    public UpdateGlnClientesCodigoByIdPrefijoCommand(long idPrefijos, long clientesCodigo)
    {
        IdPrefijos = idPrefijos;
        ClientesCodigo = clientesCodigo;
    }
}
