using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGrupoProductoByIdQuery(long Id) : IRequest<ApiResponse<GrupoProductoResponse>>;
