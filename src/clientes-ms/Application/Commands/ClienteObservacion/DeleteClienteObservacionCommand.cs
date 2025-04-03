using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteClienteObservacionCommand(long IdClienteObservacion) : IRequest<ApiResponse<bool>>;