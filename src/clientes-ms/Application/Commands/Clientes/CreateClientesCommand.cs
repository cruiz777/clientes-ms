using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateClientesCommand(ClientesRequest Request) : IRequest<ApiResponse<bool>>;