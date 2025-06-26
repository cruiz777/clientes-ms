using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Prefijos;

public record GetPrefijoUnitByClienteCodigoQuery(long ClientesCodigo) 
    : IRequest<ApiResponse<IEnumerable<PrefijoSimpleResponse>>>;
