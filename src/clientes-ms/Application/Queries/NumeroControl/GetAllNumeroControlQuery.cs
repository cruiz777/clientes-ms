using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllNumeroControlQuery : IRequest<ApiResponse<IEnumerable<NumeroControlResponse>>>;