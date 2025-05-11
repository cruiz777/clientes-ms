using clientes_ms.Application.Records.Response;
using MediatR;

public record GetTipoLocalizacionByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<TipoLocalizacionResponse>>>;
