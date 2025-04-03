using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteNumeroControlCommand(long IdNumeroControl) : IRequest<ApiResponse<bool>>;