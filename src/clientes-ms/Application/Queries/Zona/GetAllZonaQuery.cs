using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllZonaQuery : IRequest<ApiResponse<IEnumerable<ZonaResponse>>>;