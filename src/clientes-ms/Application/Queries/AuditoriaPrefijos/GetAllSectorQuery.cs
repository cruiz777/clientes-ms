using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllAuditoriaPrefijosQuery : IRequest<ApiResponse<IEnumerable<AuditoriaPrefijosResponse>>>;