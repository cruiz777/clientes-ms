using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateProvinciaCommand(ProvinciaRequest Request) : IRequest<ApiResponse<bool>>;