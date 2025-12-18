// Application/Features/CodigosContables/Queries/GetCodContableByPersonaHandler.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetCodContableByPersonaHandler
    : IRequestHandler<GetCodContableByPersonaQuery, ApiResponse<CodContablePersonaResponse>>
{
    private readonly IBaseRepository<CodigosContables> _repository;

    public GetCodContableByPersonaHandler(IBaseRepository<CodigosContables> repository)
        => _repository = repository;

    public async Task<ApiResponse<CodContablePersonaResponse>> Handle(
        GetCodContableByPersonaQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            // Buscamos el PRIMER código contable activo para esa persona
            var e = await _repository.AsQueryable()
                .Where(c => c.IdPersona == request.IdPersona && c.Estado)
                .OrderBy(c => c.IdCodContable)
                .FirstOrDefaultAsync(cancellationToken);

            if (e == null)
            {
                return new ApiResponse<CodContablePersonaResponse>(
                    Guid.NewGuid(),
                    "OBJECT",
                    null,
                    $"No existe código contable para la persona {request.IdPersona}.");
            }

            var dto = new CodContablePersonaResponse(e.IdCodContable, e.IdPersona);

            return new ApiResponse<CodContablePersonaResponse>(
                Guid.NewGuid(),
                "OBJECT",
                dto,
                "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<CodContablePersonaResponse>(
                Guid.NewGuid(),
                "ERROR",
                null,
                ex.Message);
        }
    }
}
