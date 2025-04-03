using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteGrupoProductoCommand(long IdGrupoProducto) : IRequest<ApiResponse<bool>>;