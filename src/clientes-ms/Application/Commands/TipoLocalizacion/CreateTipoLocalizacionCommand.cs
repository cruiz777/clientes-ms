using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateTipoLocalizacionCommand(TipoLocalizacionRequest Request) : IRequest<ApiResponse<bool>>;