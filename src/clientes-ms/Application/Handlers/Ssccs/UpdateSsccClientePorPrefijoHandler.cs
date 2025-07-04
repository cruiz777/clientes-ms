using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace clientes_ms.Application.Handlers.Ssccs;

public class UpdateSsccClientePorPrefijoHandler : IRequestHandler<UpdateSsccClientePorPrefijoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Sscc> _repository;
    private readonly ILogger<UpdateSsccClientePorPrefijoHandler> _logger;

    public UpdateSsccClientePorPrefijoHandler(
        IBaseRepository<Sscc> repository,
        ILogger<UpdateSsccClientePorPrefijoHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateSsccClientePorPrefijoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Actualizando SSCC con IdPrefijo {IdPrefijo} para asignar NuevoIdCliente {NuevoIdCliente}",
                request.IdPrefijo, request.NuevoIdCliente);

            var ssccList = await _repository.AsQueryable()
                .Where(s => s.IdPrefijo == request.IdPrefijo)
                .ToListAsync(cancellationToken);

            if (!ssccList.Any())
            {
                _logger.LogWarning("No se encontraron registros SSCC con IdPrefijo {IdPrefijo}", request.IdPrefijo);
                return ApiResponse<bool>.Error("No se encontraron registros SSCC para el prefijo especificado.");
            }

            foreach (var sscc in ssccList)
            {
                sscc.IdCliente = request.NuevoIdCliente;
                await _repository.UpdateAsync(sscc.IdSscc, sscc);
            }

            _logger.LogInformation("✅ Se actualizaron {Count} registros SSCC con el nuevo cliente", ssccList.Count);

            return new ApiResponse<bool>(
                Id: Guid.NewGuid(),
                Type: "SUCCESS",
                Data: true,
                Message: $"Se actualizaron {ssccList.Count} registros SSCC correctamente."
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "❌ Error al actualizar SSCC por IdPrefijo");
            return ApiResponse<bool>.Error("Ocurrió un error al actualizar los registros SSCC.");
        }
    }
}
