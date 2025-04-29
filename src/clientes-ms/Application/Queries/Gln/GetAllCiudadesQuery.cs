using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllGlnQuery : IRequest<ApiResponse<IEnumerable<GlnResponse>>>;