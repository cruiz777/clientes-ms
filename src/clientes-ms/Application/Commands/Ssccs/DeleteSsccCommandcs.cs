using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Ssccs;
public record DeleteSsccCommand(List<long> Ids, string Observacion, long Usuario) : IRequest<ApiResponse<bool>>;

