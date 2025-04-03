using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateVendedorCommand(VendedorRequest Request) : IRequest<ApiResponse<bool>>;