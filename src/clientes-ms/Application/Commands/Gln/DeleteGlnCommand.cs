using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteGlnCommand(long IdPrefijos) : IRequest<ApiResponse<bool>>;