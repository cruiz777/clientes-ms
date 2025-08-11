using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Ssccs;

public class UpdateSsccStatusHandler : IRequestHandler<UpdateSsccStatusCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Sscc> _repository;

    public UpdateSsccStatusHandler(IBaseRepository<Sscc> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateSsccStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return new ApiResponse<bool>(Guid.NewGuid(), "NOT_FOUND", false, "No se encontró el SSCC.");

            // Solo actualiza el estado del sscc
            entity.Estado = request.Estado;

            await _repository.UpdateAsync(request.Id, entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "SUCCESS", true, "Estado del SSCC actualizado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}