using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.TipoCodigoGs1;

public record GetTipoCodigoGs1ByIdQuery(long Id) : IRequest<ApiResponse<TipoCodigoGs1Response>>;
