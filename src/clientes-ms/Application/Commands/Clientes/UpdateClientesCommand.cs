using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateClientesCommand(long IdClientes, ClientesRequest Request) : IRequest<ApiResponse<bool>>;