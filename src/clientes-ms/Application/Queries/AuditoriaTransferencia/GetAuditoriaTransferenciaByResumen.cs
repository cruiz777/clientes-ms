using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAuditoriaTransferenciaByResumen : IRequest<ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>>;
