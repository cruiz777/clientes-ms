using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class UpdateClienteObservacionHandler : IRequestHandler<UpdateClienteObservacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;

    public UpdateClienteObservacionHandler(IBaseRepository<ClienteObservacion> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateClienteObservacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository
                .AsQueryable()
                .FirstOrDefaultAsync(o =>
                    o.ClientesCodigo == request.ClientesCodigo &&
                    o.Linea == request.Linea, cancellationToken);

            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"No se encontró observación con cliente {request.ClientesCodigo} y línea {request.Linea}"
                );
            }

            // ✅ Actualiza solo los campos permitidos
            existing.Detalle = request.Request.Detalle?.Trim();
            existing.Fecha = request.Request.Fecha;
            existing.IdUsuario = request.Request.IdUsuario;
            existing.NombreUsuario = request.Request.NombreUsuario;

            await _repository.UpdateAsync(existing.IdClienteObservacion, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Actualización exitosa"
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
