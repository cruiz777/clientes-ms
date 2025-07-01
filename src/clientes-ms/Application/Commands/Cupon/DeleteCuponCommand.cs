using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Cupon;

public record DeleteCuponCommand(
    List<long> Ids,
    string Observacion,
    long Usuario
) : IRequest<ApiResponse<bool>>;