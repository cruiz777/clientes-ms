using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateGrupoEmpresaHandler : IRequestHandler<CreateGrupoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    public CreateGrupoEmpresaHandler(IBaseRepository<GrupoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateGrupoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new GrupoEmpresa {
                Codigo = request.Request.Codigo.Trim(),
                Nombre = request.Request.Nombre.Trim(),
                Inscripcion = request.Request.Inscripcion,
                Asignacion = request.Request.Asignacion,
                Mantenimiento = request.Request.Mantenimiento,
                Fecha = request.Request.Fecha,
                ProductoInscripcion = request.Request.ProductoInscripcion.Trim(),
                ProductoMantenimiento = request.Request.ProductoMantenimiento.Trim(),
                ProductoAsignacion = request.Request.ProductoAsignacion.Trim(),
                AsignacionDolar = request.Request.AsignacionDolar,
                MantenimientoDolar = request.Request.MantenimientoDolar,
                InscripcionDolar = request.Request.InscripcionDolar,
                ValorAnual = request.Request.ValorAnual
            };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}