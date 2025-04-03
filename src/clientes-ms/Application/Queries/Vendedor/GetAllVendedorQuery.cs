using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllVendedorQuery : IRequest<ApiResponse<IEnumerable<VendedorResponse>>>;