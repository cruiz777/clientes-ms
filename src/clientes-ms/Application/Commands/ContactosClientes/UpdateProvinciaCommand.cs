using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateContactosClientesCommand(long Id, ContactosClientesRequest Request) : IRequest<ApiResponse<bool>>;