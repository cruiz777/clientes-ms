using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllProvinciaQuery : IRequest<ApiResponse<IEnumerable<ProvinciaResponse>>>;