using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateGrupoEmpresaCommand(long IdGrupoEmpresa, GrupoEmpresaRequest Request) : IRequest<ApiResponse<bool>>;