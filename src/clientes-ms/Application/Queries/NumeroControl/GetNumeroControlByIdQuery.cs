using clientes_ms.Application.Records.Response;
using MediatR;

public record GetNumeroControlByIdQuery(long Id) : IRequest<ApiResponse<NumeroControlResponse>>;
