using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateVendedorHandler : IRequestHandler<UpdateVendedorCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Vendedor> _repository;
    public UpdateVendedorHandler(IBaseRepository<Vendedor> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateVendedorCommand request, CancellationToken cancellationToken)
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
                    $"Vendedor with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Ruc = request.Request.Ruc.Trim();
            existing.PorVendedor = request.Request.PorVendedor.Trim();
            existing.Fecing = request.Request.Fecing;
            existing.Fecsal = request.Request.Fecsal;
            existing.Estado = request.Request.Estado;
            existing.EmpresaCodigo = request.Request.EmpresaCodigo;
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
