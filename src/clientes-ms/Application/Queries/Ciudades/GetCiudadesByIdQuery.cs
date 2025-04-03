using clientes_ms.Application.Records.Response;
using MediatR;

public record GetCiudadesByIdQuery(long Id) : IRequest<ApiResponse<CiudadesResponse>>;
