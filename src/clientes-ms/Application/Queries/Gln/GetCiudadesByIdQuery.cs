using clientes_ms.Application.Records.Response;
using MediatR;

public record GetGlnByIdQuery(long Id) : IRequest<ApiResponse<GlnResponse>>;
