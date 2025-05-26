using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateGrupoEmpresaHandler : IRequestHandler<CreateGrupoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    private readonly IGrupoEmpresaDomainService _domainService;

    public CreateGrupoEmpresaHandler(
        IBaseRepository<GrupoEmpresa> repository,
        IGrupoEmpresaDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<ApiResponse<bool>> Handle(CreateGrupoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validación: Código duplicado
            if (await _domainService.CodigoYaExisteAsync(request.Request.Codigo!))
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un grupo de cliente con ese código.");

            // Validación: Nombre duplicado
            if (await _domainService.NombreYaExisteAsync(request.Request.Nombre!))
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un grupo de cliente con ese nombre.");

            // Crear nueva entidad
            var entity = new GrupoEmpresa
            {
                Codigo = request.Request.Codigo.Trim(),
                Nombre = request.Request.Nombre.Trim(),
                Inscripcion = request.Request.Inscripcion,
                Asignacion = request.Request.Asignacion,
                Mantenimiento = request.Request.Mantenimiento,
                Fecha = request.Request.Fecha,
                ProductoInscripcion = request.Request.ProductoInscripcion!.Trim(),
                ProductoMantenimiento = request.Request.ProductoMantenimiento!.Trim(),
                ProductoAsignacion = request.Request.ProductoAsignacion!.Trim(),
                AsignacionDolar = request.Request.AsignacionDolar,
                MantenimientoDolar = request.Request.MantenimientoDolar,
                InscripcionDolar = request.Request.InscripcionDolar,
                ValorAnual = request.Request.ValorAnual,
                Estado = request.Request.Estado
            };

            await _repository.AddAsync(entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Creado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
