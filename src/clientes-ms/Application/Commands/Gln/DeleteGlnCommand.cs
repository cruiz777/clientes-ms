using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteGlnCommand(long IdCiudad) : IRequest<ApiResponse<bool>>;