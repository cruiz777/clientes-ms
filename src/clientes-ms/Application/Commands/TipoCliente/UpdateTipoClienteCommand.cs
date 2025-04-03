using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateTipoClienteCommand(long IdTipoCliente, TipoClienteRequest Request) : IRequest<ApiResponse<bool>>;