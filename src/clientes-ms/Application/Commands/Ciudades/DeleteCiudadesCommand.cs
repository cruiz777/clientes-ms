using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteCiudadesCommand(long IdCiudad) : IRequest<ApiResponse<bool>>;