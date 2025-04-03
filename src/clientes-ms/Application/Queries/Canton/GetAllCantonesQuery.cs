using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllCantonesQuery : IRequest<ApiResponse<IEnumerable<CantonesResponse>>>;