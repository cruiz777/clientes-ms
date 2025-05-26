using clientes_ms.Application.Records.Response;
using MediatR;

public record GetPrefijosByCodigoClienteQuery(long ClientesCodigo) : IRequest<ApiResponse<IEnumerable<PrefijosResponse>>>;
