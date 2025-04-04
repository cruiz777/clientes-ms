using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteClientesCommand(long IdClientes) : IRequest<ApiResponse<bool>>;