using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateVendedorCommand(long Id, VendedorRequest Request) : IRequest<ApiResponse<bool>>;
