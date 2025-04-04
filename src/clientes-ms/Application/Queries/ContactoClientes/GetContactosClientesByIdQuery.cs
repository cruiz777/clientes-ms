using clientes_ms.Application.Records.Response;
using MediatR;

public record GetContactosClientesByIdQuery(long Id) : IRequest<ApiResponse<ContactosClientesResponse>>;
