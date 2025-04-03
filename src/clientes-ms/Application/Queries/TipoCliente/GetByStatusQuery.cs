using clientes_ms.Application.Records.Response;
using MediatR;

public record GetTipoClienteByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<TipoClienteResponse>>>;
