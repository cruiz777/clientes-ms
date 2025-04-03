using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteVendedorCommand(long IdVendedor) : IRequest<ApiResponse<bool>>;