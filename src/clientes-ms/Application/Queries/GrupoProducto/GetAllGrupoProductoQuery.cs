using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllGrupoProductoQuery : IRequest<ApiResponse<IEnumerable<GrupoProductoResponse>>>;