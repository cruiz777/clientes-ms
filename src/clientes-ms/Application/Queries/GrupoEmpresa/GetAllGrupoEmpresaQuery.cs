using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllGrupoEmpresaQuery : IRequest<ApiResponse<IEnumerable<GrupoEmpresaResponse>>>;