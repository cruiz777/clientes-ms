using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class UpdateContactosClientesHandler : IRequestHandler<UpdateContactosClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;

    public UpdateContactosClientesHandler(IBaseRepository<ContactosClientes> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateContactosClientesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.AsQueryable()
                .FirstOrDefaultAsync(c =>
                    c.ClientesCodigo == request.Request.ClientesCodigo &&
                    c.Linea == request.Request.Linea,
                    cancellationToken
                );

            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"No se encontró contacto con ClientesCodigo = {request.Request.ClientesCodigo} y Linea = {request.Request.Linea}."
                );
            }

            // Actualizar solo campos permitidos
            existing.Nombre = request.Request.Nombre?.Trim() ?? "";
            existing.Telefono = request.Request.Telefono?.Trim() ?? "";
            existing.Email = request.Request.Email?.Trim() ?? "";
            // existing.Cargo = request.Request.Cargo?.Trim(); // si deseas permitirlo

            await _repository.UpdateAsync(existing.IdContactosClientes, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Actualizado correctamente"
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
