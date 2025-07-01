using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Cupon;

public record CreateCuponCommand(CuponRequest Request) : IRequest<ApiResponse<List<string>>>;
