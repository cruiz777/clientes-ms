using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteContactosClientesCommand(long IdContactosClientes) : IRequest<ApiResponse<bool>>;