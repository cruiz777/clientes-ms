using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public class UpdateContactosClientesCommand : IRequest<ApiResponse<bool>>
{
    public ContactosClientesRequest Request { get; set; }

    public UpdateContactosClientesCommand(ContactosClientesRequest request)
    {
        Request = request;
    }
}
