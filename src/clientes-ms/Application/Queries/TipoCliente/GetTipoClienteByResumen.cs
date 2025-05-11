using clientes_ms.Application.Records.Response;
using MediatR;

public record GetTipoClienteByResumen : IRequest<ApiResponse<IEnumerable<TipoClienteResponse>>>;
