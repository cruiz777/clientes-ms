using clientes_ms.Application.Records.Response;
using MediatR;

public record GetHistorialClienteByResumen : IRequest<ApiResponse<IEnumerable<HistorialClienteResponse>>>;
