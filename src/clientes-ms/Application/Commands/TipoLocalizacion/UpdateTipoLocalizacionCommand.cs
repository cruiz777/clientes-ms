using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateTipoLocalizacionCommand(long IdTipoLocalizacion, TipoLocalizacionRequest Request) : IRequest<ApiResponse<bool>>;