using clientes_ms.Application.Commands;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace clientes_ms.Application.Handlers;

public class UpdateCuponEstadoHandler : IRequestHandler<UpdateCuponEstadoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Cupones> _cuponRepository; // Asume que tu entidad se llama Cupon
    private readonly ILogger<UpdateCuponEstadoHandler> _logger;

    public UpdateCuponEstadoHandler(
        IBaseRepository<Cupones> cuponRepository,
        ILogger<UpdateCuponEstadoHandler> logger)
    {
        _cuponRepository = cuponRepository;
        _logger = logger;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateCuponEstadoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Actualizando estado del cupón con ID: {Id} a estado: {Estado}",
                request.Id, request.Estado);

            // Buscar el cupón existente
            var cupon = await _cuponRepository.GetByIdAsync(request.Id);
            if (cupon == null)
            {
                _logger.LogWarning("Cupón con ID: {Id} no encontrado", request.Id);
                return ApiResponse<bool>.Error($"Cupón con ID {request.Id} no encontrado");
            }

            // Actualizar solo el estado usando reflection para modificar la propiedad Estado
            var estadoProperty = cupon.GetType().GetProperty("Estado");
            if (estadoProperty != null && estadoProperty.CanWrite)
            {
                estadoProperty.SetValue(cupon, request.Estado);
            }
            else
            {
                _logger.LogError("La entidad Cupon no tiene una propiedad Estado modificable");
                return ApiResponse<bool>.Error("No se puede actualizar el estado del cupón");
            }

            // Guardar cambios usando el BaseRepository
            await _cuponRepository.UpdateAsync(request.Id, cupon);

            _logger.LogInformation("Estado del cupón con ID: {Id} actualizado exitosamente", request.Id);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "SUCCESS",
                true,
                "Estado del cupón actualizado correctamente"
            );
        }
        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex, "Cupón con ID: {Id} no encontrado", request.Id);
            return ApiResponse<bool>.Error($"Cupón con ID {request.Id} no encontrado");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inesperado al actualizar estado del cupón con ID: {Id}", request.Id);
            return ApiResponse<bool>.Error("Error interno del servidor al actualizar el estado");
        }
    }
}