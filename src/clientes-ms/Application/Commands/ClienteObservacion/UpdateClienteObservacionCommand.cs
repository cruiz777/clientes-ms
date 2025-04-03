using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateClienteObservacionCommand(long Id, ClienteObservacionRequest Request) : IRequest<ApiResponse<bool>>;
