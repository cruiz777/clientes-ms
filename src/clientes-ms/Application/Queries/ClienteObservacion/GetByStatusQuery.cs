using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClienteObservacionByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ClienteObservacionResponse>>>;
