using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public class UpdateClienteDatosAdicionalesCommand : IRequest<ApiResponse<bool>>
{
    public long ClientesCodigo { get; set; }
    public ClienteDatosAdicionalesRequest Request { get; set; }
}
