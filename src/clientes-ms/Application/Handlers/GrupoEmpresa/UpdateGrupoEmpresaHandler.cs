using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateGrupoEmpresaHandler : IRequestHandler<UpdateGrupoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    public UpdateGrupoEmpresaHandler(IBaseRepository<GrupoEmpresa> repository) => _repository = repository;

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

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Codigo = request.Request.Codigo.Trim();
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Inscripcion = request.Request.Inscripcion;
            existing.Asignacion = request.Request.Asignacion;
            existing.Mantenimiento = request.Request.Mantenimiento;
            existing.Fecha = request.Request.Fecha;
            existing.ProductoInscripcion = request.Request.ProductoInscripcion.Trim();
            existing.ProductoMantenimiento = request.Request.ProductoMantenimiento.Trim();
            existing.ProductoAsignacion = request.Request.ProductoAsignacion.Trim();
            existing.AsignacionDolar = request.Request.AsignacionDolar;
            existing.MantenimientoDolar = request.Request.MantenimientoDolar;
            existing.InscripcionDolar = request.Request.InscripcionDolar;
            existing.ValorAnual = request.Request.ValorAnual;


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
