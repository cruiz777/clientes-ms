using clientes_ms.Application.Records.Response;
using MediatR;

public record GetHistorialClienteByCodigoClienteQuery(long ClientesCodigo) : IRequest<ApiResponse<IEnumerable<HistorialClienteResponse>>>;
