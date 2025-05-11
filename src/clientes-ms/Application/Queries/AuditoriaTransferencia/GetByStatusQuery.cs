using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAuditoriaPrefijoByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>>;
