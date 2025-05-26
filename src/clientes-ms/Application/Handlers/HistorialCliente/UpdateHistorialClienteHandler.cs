using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateHistorialClienteHandler : IRequestHandler<UpdateHistorialClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;
    public UpdateHistorialClienteHandler(IBaseRepository<HistorialCliente> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateHistorialClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdHistorialCliente);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"HistorialCliente with ID {request.IdHistorialCliente} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.IdUsuario=request.Request.IdUsuario;
            existing.NombreUsuario=request.Request.NombreUsuario;
            existing.Fecha=request.Request.Fecha;
            existing.ClientesCodigo=request.Request.ClientesCodigo;
            existing.Descripcion = request.Request.Descripcion.Trim();
            existing.Tabla = request.Request.Tabla;
            existing.TipoAccion=request.Request.TipoAccion;
            existing.IdEmpresa=request.Request.IdEmpresa;
      
            await _repository.UpdateAsync(request.IdHistorialCliente, existing);

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
