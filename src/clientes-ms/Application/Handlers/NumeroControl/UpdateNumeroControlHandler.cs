using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateNumeroControlHandler : IRequestHandler<UpdateNumeroControlCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<NumeroControl> _repository;
    public UpdateNumeroControlHandler(IBaseRepository<NumeroControl> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateNumeroControlCommand request, CancellationToken cancellationToken)
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
                    $"NumeroControl with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Codcon = request.Request.Codcon;
            existing.Modcon = request.Request.Modcon.Trim();
            existing.Tipcon = request.Request.Tipcon.Trim();
            existing.Numcon = request.Request.Numcon.Trim();
            existing.Ocupado = request.Request.Ocupado;
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
