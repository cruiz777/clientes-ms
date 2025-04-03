using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGrupoEmpresaByIdQuery(long Id) : IRequest<ApiResponse<GrupoEmpresaResponse>>;
