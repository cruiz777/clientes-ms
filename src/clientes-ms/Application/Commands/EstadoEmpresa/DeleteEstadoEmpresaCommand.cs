using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteEstadoEmpresaCommand(long IdEstadoEmpresa) : IRequest<ApiResponse<bool>>;