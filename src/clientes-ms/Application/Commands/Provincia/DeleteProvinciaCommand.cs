using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteProvinciaCommand(long IdProvincia) : IRequest<ApiResponse<bool>>;