using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateGlnCommand(long Id, GlnRequest Request) : IRequest<ApiResponse<bool>>;