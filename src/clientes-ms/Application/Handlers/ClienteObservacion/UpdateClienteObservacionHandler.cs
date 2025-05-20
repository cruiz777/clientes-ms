using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateClienteObservacionHandler : IRequestHandler<UpdateClienteObservacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;
    public UpdateClienteObservacionHandler(IBaseRepository<ClienteObservacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateClienteObservacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"ClienteObservacion with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Detalle = request.Request.Detalle?.Trim();
            existing.Fecha = request.Request.Fecha;
            existing.IdUsuario = request.Request.IdUsuario;
            //existing.ClientesCodigo = request.Request.ClientesCodigo;
            existing.NombreUsuario = request.Request.NombreUsuario;
            
            await _repository.UpdateAsync(request.Id, existing);

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
