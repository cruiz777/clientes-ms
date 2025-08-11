using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateAuditoriaPrefijosCommand(AuditoriaPrefijosRequest Request) : IRequest<ApiResponse<bool>>;