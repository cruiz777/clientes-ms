using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllAuditoriaTransferenciaQuery : IRequest<ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>>;