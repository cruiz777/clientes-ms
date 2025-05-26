using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateClienteDatosAdicionalesCommand(ClienteDatosAdicionalesRequest Request) : IRequest<ApiResponse<bool>>;