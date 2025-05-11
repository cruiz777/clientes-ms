using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateAuditoriaTransferenciaHandler : IRequestHandler<UpdateAuditoriaTransferenciaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;
    public UpdateAuditoriaTransferenciaHandler(IBaseRepository<AuditoriaTransferencia> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateAuditoriaTransferenciaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdTraferenciaPrefijo);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"AuditoriaTransferencia with ID {request.IdTraferenciaPrefijo} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.ClientesCodigoOrigen=request.Request.ClientesCodigoOrigen;
            existing.ClientesCodigoDestino=request.Request.ClientesCodigoDestino;
            existing.Fecha=request.Request.Fecha;
            existing.Tipo=request.Request.Tipo;
            existing.IdUsuario=request.Request.IdUsuario;
            existing.IdPrefijos=request.Request.IdPrefijos;
            await _repository.UpdateAsync(request.IdTraferenciaPrefijo, existing);
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
