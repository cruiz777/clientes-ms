using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateAuditoriaPrefijosCommand(long Id, AuditoriaPrefijosRequest Request) : IRequest<ApiResponse<bool>>;