using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateTipoClienteCommand(TipoClienteRequest Request) : IRequest<ApiResponse<bool>>;