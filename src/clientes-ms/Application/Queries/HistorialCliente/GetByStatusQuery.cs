using clientes_ms.Application.Records.Response;
using MediatR;

public record GetHistorialClienteByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<HistorialClienteResponse>>>;
