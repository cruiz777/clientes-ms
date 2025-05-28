using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public class UpdateClienteObservacionCommand : IRequest<ApiResponse<bool>>
{
    public int ClientesCodigo { get; set; }
    public int Linea { get; set; }
    public ClienteObservacionRequest Request { get; set; }
}
