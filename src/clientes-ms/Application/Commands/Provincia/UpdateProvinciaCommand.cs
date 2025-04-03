using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateProvinciaCommand(long Id, ProvinciaRequest Request) : IRequest<ApiResponse<bool>>;