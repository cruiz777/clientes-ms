using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.TipoCodigoGs1;

public record UpdateTipoCodigoGs1Command(long Id, TipoCodigoGs1Request Request) : IRequest<ApiResponse<bool>>;
