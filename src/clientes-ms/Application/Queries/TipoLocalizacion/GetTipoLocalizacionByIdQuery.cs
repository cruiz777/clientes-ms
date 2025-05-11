using clientes_ms.Application.Records.Response;
using MediatR;

public record GetTipoLocalizacionByIdQuery(long Id) : IRequest<ApiResponse<TipoLocalizacionResponse>>;
