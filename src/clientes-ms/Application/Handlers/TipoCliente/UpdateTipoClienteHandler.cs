using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateTipoClienteHandler : IRequestHandler<UpdateTipoClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    public UpdateTipoClienteHandler(IBaseRepository<TipoCliente> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateTipoClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdTipoCliente);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"TipoCliente with ID {request.IdTipoCliente} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Descripcion = request.Request.Descripcion.Trim();

            await _repository.UpdateAsync(request.IdTipoCliente, existing);

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
