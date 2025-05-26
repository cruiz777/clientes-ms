using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllHistorialClienteQuery : IRequest<ApiResponse<IEnumerable<HistorialClienteResponse>>>;