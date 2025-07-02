using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdatePrefijosClientesCodigoPrefijoHandler : IRequestHandler<UpdatePrefijoClientesCodigoPrefijoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Prefijos> _repository;

    public UpdatePrefijosClientesCodigoPrefijoHandler(IBaseRepository<Prefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdatePrefijoClientesCodigoPrefijoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdPrefijos);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"No se encontró el prefijo con ID {request.IdPrefijos}"
                );
            }

            // ✅ Actualiza solo ClientesCodigo
            existing.ClientesCodigo = request.ClientesCodigo;

            await _repository.UpdateAsync(request.IdPrefijos, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "ClientesCodigo actualizado correctamente."
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
