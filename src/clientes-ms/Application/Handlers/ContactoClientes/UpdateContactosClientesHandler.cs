using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateContactosClientesHandler : IRequestHandler<UpdateContactosClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;
    public UpdateContactosClientesHandler(IBaseRepository<ContactosClientes> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateContactosClientesCommand request, CancellationToken cancellationToken)
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
                    $"ContactoClientes with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Telefono = request.Request.Telefono.Trim();
            existing.Email = request.Request.Email.Trim();
            existing.Cargo = request.Request.Cargo.Trim();
            existing.ClientesCodigo = request.Request.ClientesCodigo;
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
