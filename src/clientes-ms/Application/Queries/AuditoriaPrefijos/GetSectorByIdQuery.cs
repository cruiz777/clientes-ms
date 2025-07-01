using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAuditoriaPrefijosByIdQuery(long Id) : IRequest<ApiResponse<AuditoriaPrefijosResponse>>;
