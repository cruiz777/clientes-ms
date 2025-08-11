using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateAuditoriaPrefijosHandler : IRequestHandler<UpdateAuditoriaPrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaPrefijos> _repository;

    public UpdateAuditoriaPrefijosHandler(IBaseRepository<AuditoriaPrefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateAuditoriaPrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", false, $"No existe el ID {request.Id}");
            }

            entity.Codpre = request.Request.Codpre?.Trim();
            entity.Usuario = request.Request.Usuario?.Trim();
            entity.Fecha = request.Request.Fecha?.Trim();
            entity.Empresa = request.Request.Empresa?.Trim();
            entity.Ruc = request.Request.Ruc?.Trim();

            await _repository.UpdateAsync(entity.Id, entity); // ← CORREGIDO

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Actualizado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }

}
