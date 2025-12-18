// Application/Features/CodigosContables/Queries/GetCodContableByPersonaQuery.cs
using clientes_ms.Application.Records.Response;
using MediatR;

public record GetCodContableByPersonaQuery(long IdPersona)
    : IRequest<ApiResponse<CodContablePersonaResponse>>;
