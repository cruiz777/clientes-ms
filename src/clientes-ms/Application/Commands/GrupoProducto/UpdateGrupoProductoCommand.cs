using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateGrupoProductoCommand(long IdGrupoProducto, GrupoProductoRequest Request) : IRequest<ApiResponse<bool>>;