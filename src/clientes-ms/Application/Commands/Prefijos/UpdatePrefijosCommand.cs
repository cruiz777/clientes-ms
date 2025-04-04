using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdatePrefijosCommand(long IdPrefijos, PrefijosRequest Request) : IRequest<ApiResponse<bool>>;