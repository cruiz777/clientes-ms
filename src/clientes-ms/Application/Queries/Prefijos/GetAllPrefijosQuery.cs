using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllPrefijosQuery : IRequest<ApiResponse<IEnumerable<PrefijosResponse>>>;