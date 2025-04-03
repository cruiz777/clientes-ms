using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateCiudadesHandler : IRequestHandler<UpdateCiudadesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public UpdateCiudadesHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateCiudadesCommand request, CancellationToken cancellationToken)
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
                    $"Ciudades with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Referencia = request.Request.Referencia.Trim();
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Area = request.Request.Nombre.Trim();
            existing.IdCanton = request.Request.IdCanton;
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
