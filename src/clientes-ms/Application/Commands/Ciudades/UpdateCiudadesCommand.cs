using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateCiudadesCommand(long Id, CiudadesRequest Request) : IRequest<ApiResponse<bool>>;