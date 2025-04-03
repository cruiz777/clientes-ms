using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateCantonHandler : IRequestHandler<UpdateCantonesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Cantones> _repository;
    public UpdateCantonHandler(IBaseRepository<Cantones> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateCantonesCommand request, CancellationToken cancellationToken)
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
                    $"Canton with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Referencia = request.Request.Referencia.Trim();
            existing.Nombre = request.Request.Nombre.Trim();
            existing.IdProvincia = request.Request.IdProvincia;
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
