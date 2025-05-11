using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteTipoLocalizacionCommand(long IdTipoLocalizacion) : IRequest<ApiResponse<bool>>;