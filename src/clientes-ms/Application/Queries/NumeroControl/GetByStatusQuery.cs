using clientes_ms.Application.Records.Response;
using MediatR;

public record GetNumeroControlByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<NumeroControlResponse>>>;
