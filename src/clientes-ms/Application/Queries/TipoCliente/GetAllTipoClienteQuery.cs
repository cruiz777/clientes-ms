using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllTipoClienteQuery : IRequest<ApiResponse<IEnumerable<TipoClienteResponse>>>;