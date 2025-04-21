using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClientesByIdQuery(long Id) : IRequest<ApiResponse<ClientesResponse>>;
