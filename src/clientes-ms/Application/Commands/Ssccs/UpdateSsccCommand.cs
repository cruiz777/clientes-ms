using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.Ssccs
{
    public record UpdateSsccCommand(long Id, SsccRequest Request) : IRequest<ApiResponse<bool>>;
}
