using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateHistorialClienteCommand(long IdHistorialCliente, HistorialClienteRequest Request) : IRequest<ApiResponse<bool>>;