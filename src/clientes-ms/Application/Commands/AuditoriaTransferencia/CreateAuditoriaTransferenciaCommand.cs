using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateAuditoriaTransferenciaCommand(AuditoriaTransferenciaRequest Request) : IRequest<ApiResponse<bool>>;