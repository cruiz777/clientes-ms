using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreatePrefijosCommand(PrefijosRequest Request) : IRequest<ApiResponse<bool>>;