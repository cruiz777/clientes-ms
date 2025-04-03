using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClienteObservacionByIdQuery(long Id) : IRequest<ApiResponse<ClienteObservacionResponse>>;
