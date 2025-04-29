using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGlnByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<GlnResponse>>>;
