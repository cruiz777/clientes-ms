using clientes_ms.Application.Records.Response;
using MediatR;

public record GetPrefijosByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<PrefijosResponse>>>;
