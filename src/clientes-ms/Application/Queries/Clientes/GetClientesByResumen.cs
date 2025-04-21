using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClientesByResumen : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>;
