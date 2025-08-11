using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGrupoProductoByCodigoQuery(string Codigo) : IRequest<ApiResponse<GrupoProductoResponse>>;
