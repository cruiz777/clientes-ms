using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateGlnCommand(GlnRequest Request) : IRequest<ApiResponse<bool>>;
