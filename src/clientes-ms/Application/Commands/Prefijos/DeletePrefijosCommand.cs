using clientes_ms.Application.Records.Response;
using MediatR;

public record DeletePrefijosCommand(long IdPrefijos) : IRequest<ApiResponse<bool>>;