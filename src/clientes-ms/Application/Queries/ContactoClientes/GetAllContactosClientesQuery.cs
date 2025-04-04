using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllContactosClientesQuery : IRequest<ApiResponse<IEnumerable<ContactosClientesResponse>>>;