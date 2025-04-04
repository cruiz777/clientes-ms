using clientes_ms.Application.Records.Response;
using MediatR;

public record GetPrefijosByIdQuery(long Id) : IRequest<ApiResponse<PrefijosResponse>>;
