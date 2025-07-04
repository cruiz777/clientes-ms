using clientes_ms.Application.Commands.Cupon;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace clientes_ms.Application.Handlers.Cupon;

public class UpdateCuponesClientePorPrefijoHandler : IRequestHandler<UpdateCuponesClientePorPrefijoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Cupones> _repository;
    private readonly ILogger<UpdateCuponesClientePorPrefijoHandler> _logger;

    public UpdateCuponesClientePorPrefijoHandler(
        IBaseRepository<Cupones> repository,
        ILogger<UpdateCuponesClientePorPrefijoHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateCuponesClientePorPrefijoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Actualizando cupones con IdPrefijo {IdPrefijo} para asignar IdCliente {NuevoIdCliente}",
                request.IdPrefijo, request.NuevoIdCliente);

            var cupones = await _repository.AsQueryable()
                .Where(c => c.IdPrefijo == request.IdPrefijo)
                .ToListAsync(cancellationToken);

            if (!cupones.Any())
            {
                _logger.LogWarning("No se encontraron cupones con IdPrefijo {IdPrefijo}", request.IdPrefijo);
                return ApiResponse<bool>.Error("No se encontraron cupones para el prefijo especificado.");
            }

            foreach (var cupon in cupones)
            {
                cupon.IdCliente = request.NuevoIdCliente;
                await _repository.UpdateAsync(cupon.IdCupon, cupon);
            }

            _logger.LogInformation("Se actualizaron {Count} cupones con el nuevo cliente", cupones.Count);

            return new ApiResponse<bool>(
                Id: Guid.NewGuid(),
                Type: "SUCCESS",
                Data: true,
                Message: $"Se actualizaron {cupones.Count} cupones correctamente."
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar los cupones por IdPrefijo");
            return ApiResponse<bool>.Error("Ocurrió un error al actualizar los cupones.");
        }
    }
}
