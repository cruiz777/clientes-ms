using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateCiudadesCommand(CiudadesRequest Request) : IRequest<ApiResponse<bool>>;