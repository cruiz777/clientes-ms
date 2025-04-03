using clientes_ms.Application.Records.Response;
using MediatR;

public record GetVendedorByIdQuery(long Id) : IRequest<ApiResponse<VendedorResponse>>;
