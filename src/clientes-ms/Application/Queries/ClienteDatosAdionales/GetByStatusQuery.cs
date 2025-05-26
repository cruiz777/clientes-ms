using clientes_ms.Application.Records.Response;
using MediatR;

public record GetClienteDatosAdicionalesByStatusQuery(bool Status) : IRequest<ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>>;
