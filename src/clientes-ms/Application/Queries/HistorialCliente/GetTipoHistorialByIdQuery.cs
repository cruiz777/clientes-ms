using clientes_ms.Application.Records.Response;
using MediatR;

public record GetHistorialClienteByIdQuery(long Id) : IRequest<ApiResponse<HistorialClienteResponse>>;
