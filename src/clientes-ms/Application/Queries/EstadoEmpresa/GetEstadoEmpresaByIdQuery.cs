using clientes_ms.Application.Records.Response;
using MediatR;

public record GetEstadoEmpresaByIdQuery(long Id) : IRequest<ApiResponse<EstadoEmpresaResponse>>;
