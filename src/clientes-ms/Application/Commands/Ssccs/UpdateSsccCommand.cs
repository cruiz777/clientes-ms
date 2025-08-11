using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Ssccs;

public record UpdateSsccStatusCommand(long Id, bool Estado) : IRequest<ApiResponse<bool>>;
