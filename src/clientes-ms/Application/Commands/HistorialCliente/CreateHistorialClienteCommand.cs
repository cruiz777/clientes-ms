using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateHistorialClienteCommand(HistorialClienteRequest Request) : IRequest<ApiResponse<bool>>;