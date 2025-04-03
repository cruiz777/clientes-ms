using clientes_ms.Application.Records.Response;
using MediatR;

public record GetZonaByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ZonaResponse>>>;
