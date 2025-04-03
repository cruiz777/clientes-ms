using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteCantonesCommand(long IdCanton) : IRequest<ApiResponse<bool>>;