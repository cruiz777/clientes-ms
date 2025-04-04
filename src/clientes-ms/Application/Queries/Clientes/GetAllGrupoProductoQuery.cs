using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllClientesQuery : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>;