using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGrupoProductoByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<GrupoProductoResponse>>>;
