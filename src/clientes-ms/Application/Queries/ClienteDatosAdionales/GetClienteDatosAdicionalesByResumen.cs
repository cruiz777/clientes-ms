using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClienteDatosAdicionalesByResumen : IRequest<ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>>;
