using clientes_ms.Application.Records.Response;
using MediatR;

public record DeleteAuditoriaTransferenciaCommand(long IdAuditoriaTransferencia) : IRequest<ApiResponse<bool>>;