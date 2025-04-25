using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClientesByRucQuery(string Ruc) : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>;
