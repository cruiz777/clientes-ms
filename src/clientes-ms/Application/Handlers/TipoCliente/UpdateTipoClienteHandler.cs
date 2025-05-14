using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateTipoClienteHandler : IRequestHandler<UpdateTipoClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    private readonly ITipoClienteDomainService _domainService;

    public UpdateTipoClienteHandler(
        IBaseRepository<TipoCliente> repository,
        ITipoClienteDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

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
                    $"TipoCliente con ID {request.IdTipoCliente} no encontrado."
                );
            }

            // Validar duplicado por descripción (excluyendo el actual)
            if (await _domainService.DescripcionYaExisteAsync(request.Request.Descripcion, request.IdTipoCliente))
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "VALIDATION",
                    false,
                    $"Ya existe un tipo de cliente con la descripción '{request.Request.Descripcion.Trim()}'."
                );
            }

            // Validar si puede desactivarse
            if (!request.Request.Estado)
            {
                var puede = await _domainService.PuedeDesactivarseAsync(request.IdTipoCliente);
                if (!puede)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "BUSINESS_RULE",
                        false,
                        "No se puede desactivar el tipo de cliente porque tiene clientes asociados."
                    );
                }
            }

            // Actualización segura
            existing.Descripcion = request.Request.Descripcion.Trim();
            existing.Cuenta = request.Request.Cuenta.Trim();
            existing.Estado = request.Request.Estado;
            existing.IdEmpresa = request.Request.IdEmpresa;

            await _repository.UpdateAsync(request.IdTipoCliente, existing);

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
