using clientes_ms.Application.Records.Response;
using MediatR;

public class GetClientesByNombreLikeQuery : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>
{
    public string Nombre { get; set; }

    public GetClientesByNombreLikeQuery(string nombre)
    {
        Nombre = nombre;
    }
}
