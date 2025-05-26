using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateGrupoEmpresaHandler : IRequestHandler<UpdateGrupoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    private readonly IGrupoEmpresaDomainService _domainService;
    public UpdateGrupoEmpresaHandler(
        IBaseRepository<GrupoEmpresa> repository,
        IGrupoEmpresaDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateGrupoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdGrupoEmpresa);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"GrupoEmpresa with ID {request.IdGrupoEmpresa} not found."
                );
            }

            // Validación: Código duplicado (si cambia)
            if (!string.Equals(existing.Codigo!.Trim(), request.Request.Codigo.Trim(), StringComparison.OrdinalIgnoreCase) &&
                await _domainService.CodigoYaExisteAsync(request.Request.Codigo, request.IdGrupoEmpresa))
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un grupo empresa con ese código.");
            }

            // Validación: Nombre duplicado (si cambia)
            if (!string.Equals(existing.Nombre!.Trim(), request.Request.Nombre!.Trim(), StringComparison.OrdinalIgnoreCase) &&
                await _domainService.NombreYaExisteAsync(request.Request.Nombre, request.IdGrupoEmpresa))
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un grupo empresa con ese nombre.");
            }
            // Validar si puede desactivarse
            if (!request.Request.Estado)
            {
                var puede = await _domainService.PuedeDesactivarseAsync(request.IdGrupoEmpresa);
                if (!puede)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "BUSINESS_RULE",
                        false,
                        "No se puede desactivar el grupo de cliente porque tiene clientes asociados."
                    );
                }
            }
            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            //existing.Codigo = request.Request.Codigo.Trim();
            //existing.Nombre = request.Request.Nombre.Trim();
            //existing.Inscripcion = request.Request.Inscripcion;
            //existing.Asignacion = request.Request.Asignacion;
            //existing.Mantenimiento = request.Request.Mantenimiento;
            //existing.Fecha = request.Request.Fecha;
            //existing.ProductoInscripcion = request.Request.ProductoInscripcion.Trim();
            //existing.ProductoMantenimiento = request.Request.ProductoMantenimiento.Trim();
            //existing.ProductoAsignacion = request.Request.ProductoAsignacion.Trim();
            //existing.AsignacionDolar = request.Request.AsignacionDolar;
            //existing.MantenimientoDolar = request.Request.MantenimientoDolar;
            //existing.InscripcionDolar = request.Request.InscripcionDolar;
            //existing.ValorAnual = request.Request.ValorAnual;
            if (request.Request.Estado)    
                existing.Estado = request.Request.Estado;

            if (request.Request.Asignacion.HasValue)
                existing.Asignacion = request.Request.Asignacion.Value;

            if (request.Request.Inscripcion.HasValue)
                existing.Inscripcion = request.Request.Inscripcion.Value;

            if (request.Request.Mantenimiento.HasValue)
                existing.Mantenimiento = request.Request.Mantenimiento.Value;

            if (request.Request.ValorAnual.HasValue)
                existing.ValorAnual = request.Request.ValorAnual.Value;


            if (request.Request.Fecha.HasValue)
                existing.Fecha = request.Request.Fecha.Value;




            await _repository.UpdateAsync(request.IdGrupoEmpresa, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Updated successfully"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "ERROR",
                false,
                ex.Message
            );
        }
    }
}
