using clientes_ms.Application.Records.Response;
using MediatR;

public record GetEstadoEmpresaByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<EstadoEmpresaResponse>>>;
