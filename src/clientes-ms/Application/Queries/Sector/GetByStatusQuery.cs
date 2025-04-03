using clientes_ms.Application.Records.Response;
using MediatR;

public record GetSectorByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<SectorResponse>>>;
