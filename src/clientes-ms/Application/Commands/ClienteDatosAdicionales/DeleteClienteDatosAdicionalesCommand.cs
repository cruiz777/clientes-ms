using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteClienteDatosAdicionalesCommand(long IdClienteDatosAdicionales) : IRequest<ApiResponse<bool>>;