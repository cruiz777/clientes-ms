using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.TipoCodigoGs1;

public record GetAllTipoCodigoGs1Query : IRequest<ApiResponse<IEnumerable<TipoCodigoGs1Response>>>;
