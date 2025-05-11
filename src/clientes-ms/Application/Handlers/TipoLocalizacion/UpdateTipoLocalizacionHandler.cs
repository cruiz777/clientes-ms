using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateTipoLocalizacionHandler : IRequestHandler<UpdateTipoLocalizacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    public UpdateTipoLocalizacionHandler(IBaseRepository<TipoLocalizacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateTipoLocalizacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdTipoLocalizacion);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"TipoLocalizacion with ID {request.IdTipoLocalizacion} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Descripcion = request.Request.Descripcion.Trim();
            existing.Estado = request.Request.Estado;
           
            await _repository.UpdateAsync(request.IdTipoLocalizacion, existing);

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
