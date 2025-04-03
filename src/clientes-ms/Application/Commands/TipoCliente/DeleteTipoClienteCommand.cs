using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteTipoClienteCommand(long IdTipoCliente) : IRequest<ApiResponse<bool>>;