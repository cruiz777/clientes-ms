using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGrupoEmpresaByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<GrupoEmpresaResponse>>>;
