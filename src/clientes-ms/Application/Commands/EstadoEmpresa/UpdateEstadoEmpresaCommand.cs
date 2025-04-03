using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateEstadoEmpresaCommand(long Id, EstadoEmpresaRequest Request) : IRequest<ApiResponse<bool>>;