using clientes_ms.Application.Records.Response;
using MediatR;

public class GetContactosClientesByClientesCodigoQuery : IRequest<ApiResponse<List<ContactosClientesResponse>>>
{
    public int ClientesCodigo { get; set; }

    public GetContactosClientesByClientesCodigoQuery(int clientesCodigo)
    {
        ClientesCodigo = clientesCodigo;
    }
}
