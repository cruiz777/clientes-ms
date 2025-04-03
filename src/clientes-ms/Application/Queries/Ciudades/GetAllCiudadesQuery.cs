using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllCiudadesQuery : IRequest<ApiResponse<IEnumerable<CiudadesResponse>>>;