using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteGrupoEmpresaCommand(long IdGrupoEmpresa) : IRequest<ApiResponse<bool>>;