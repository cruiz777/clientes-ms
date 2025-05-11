using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllTipoLocalizacionQuery : IRequest<ApiResponse<IEnumerable<TipoLocalizacionResponse>>>;