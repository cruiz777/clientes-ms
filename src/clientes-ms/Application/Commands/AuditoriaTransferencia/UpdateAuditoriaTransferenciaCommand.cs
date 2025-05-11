using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;

public record UpdateAuditoriaTransferenciaCommand(long IdTraferenciaPrefijo, AuditoriaTransferenciaRequest Request) : IRequest<ApiResponse<bool>>;