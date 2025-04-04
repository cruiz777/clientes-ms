using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateContactosClientesCommand(ContactosClientesRequest Request) : IRequest<ApiResponse<bool>>;