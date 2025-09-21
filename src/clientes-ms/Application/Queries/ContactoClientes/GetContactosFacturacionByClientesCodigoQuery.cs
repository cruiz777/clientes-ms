using clientes_ms.Application.Records.Response;
using MediatR;

public class GetContactosFacturacionByClientesCodigoQuery
    : IRequest<ApiResponse<List<ContactosClientesResponse>>>
{
    public long ClientesCodigo { get; set; }

    public GetContactosFacturacionByClientesCodigoQuery(long clientesCodigo)
    {
        ClientesCodigo = clientesCodigo;
    }
}
