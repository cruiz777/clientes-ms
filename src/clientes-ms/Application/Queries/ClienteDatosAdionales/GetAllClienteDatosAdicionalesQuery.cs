using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllClienteDatosAdicionalesQuery : IRequest<ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>>;