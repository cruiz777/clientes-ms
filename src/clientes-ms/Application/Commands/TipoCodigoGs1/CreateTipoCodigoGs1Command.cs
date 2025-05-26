using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.TipoCodigoGs1;

public record CreateTipoCodigoGs1Command(TipoCodigoGs1Request Request) : IRequest<ApiResponse<bool>>;
