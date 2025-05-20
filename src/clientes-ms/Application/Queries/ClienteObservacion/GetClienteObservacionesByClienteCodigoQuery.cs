using clientes_ms.Application.Records.Response;
using MediatR;

public class GetClienteObservacionesByClienteCodigoQuery : IRequest<ApiResponse<IEnumerable<ClienteObservacionResponse>>>
{
    public long ClientesCodigo { get; set; }

    public GetClienteObservacionesByClienteCodigoQuery(long clientesCodigo)
    {
        ClientesCodigo = clientesCodigo;
    }
}
