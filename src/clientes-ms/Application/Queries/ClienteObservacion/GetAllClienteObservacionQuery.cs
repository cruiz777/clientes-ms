using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllClienteObservacionQuery : IRequest<ApiResponse<IEnumerable<ClienteObservacionResponse>>>;