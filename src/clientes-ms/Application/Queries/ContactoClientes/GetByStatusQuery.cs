using clientes_ms.Application.Records.Response;
using MediatR;

public record GetContactosClientesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ContactosClientesResponse>>>;
