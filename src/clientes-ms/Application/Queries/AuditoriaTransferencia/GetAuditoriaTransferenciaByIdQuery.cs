using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAuditoriaTransferenciaByIdQuery(long Id) : IRequest<ApiResponse<AuditoriaTransferenciaResponse>>;
