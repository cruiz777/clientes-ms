using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteGlnByIdPrefijosCommand(long IdPrefijos) : IRequest<ApiResponse<bool>>;
