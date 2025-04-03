using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateEstadoEmpresaHandler : IRequestHandler<UpdateEstadoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<EstadoEmpresa> _repository;
    public UpdateEstadoEmpresaHandler(IBaseRepository<EstadoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateEstadoEmpresaCommand request, CancellationToken cancellationToken)
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
                    $"EstadoEmpresa with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Fecha = request.Request.Fecha;
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
