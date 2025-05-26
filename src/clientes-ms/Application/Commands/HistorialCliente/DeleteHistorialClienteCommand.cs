using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteHistorialClienteCommand(long IdHistorialCliente) : IRequest<ApiResponse<bool>>;