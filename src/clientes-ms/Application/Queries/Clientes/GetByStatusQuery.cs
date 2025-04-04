using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClientesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>;
