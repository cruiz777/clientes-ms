using clientes_ms.Application.Records.Response;
using MediatR;

public record GetTipoClienteByIdQuery(long Id) : IRequest<ApiResponse<TipoClienteResponse>>;
