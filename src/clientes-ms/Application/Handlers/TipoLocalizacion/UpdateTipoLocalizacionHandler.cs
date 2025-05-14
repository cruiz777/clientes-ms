using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateTipoLocalizacionHandler : IRequestHandler<UpdateTipoLocalizacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    private readonly ITipoLocalizacionDomainService _domainService;

    public UpdateTipoLocalizacionHandler(
        IBaseRepository<TipoLocalizacion> repository,
        ITipoLocalizacionDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateTipoLocalizacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdTipoLocalizacion);
            if (existing == null)
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "OBJECT", false, $"TipoLocalizacion con ID {request.IdTipoLocalizacion} no encontrado.");
            }

            // Validar duplicado si la descripción cambió
            if (!string.Equals(existing.Descripcion!.Trim(), request.Request.Descripcion.Trim(), StringComparison.OrdinalIgnoreCase) &&
                await _domainService.DescripcionYaExisteAsync(request.Request.Descripcion, request.IdTipoLocalizacion))
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un tipo de localización con esa descripción.");
            }

            // Validar si se puede desactivar (si está cambiando a estado = false)
            if (request.Request.Estado == false && existing.Estado == true)
            {
                var puedeDesactivarse = await _domainService.PuedeDesactivarseAsync(request.IdTipoLocalizacion);
                if (!puedeDesactivarse)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "BUSINESS_RULE",
                        false,
                        "No se puede desactivar el tipo de localización porque está asociado a GLN(s).");
                }
            }


            // Actualizar campos permitidos
            existing.Descripcion = request.Request.Descripcion.Trim();
            existing.Estado = request.Request.Estado;

            await _repository.UpdateAsync(request.IdTipoLocalizacion, existing);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Actualizado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
