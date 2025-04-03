using clientes_ms.Application.Records.Response;
using MediatR;

public record GetCiudadesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<CiudadesResponse>>>;
