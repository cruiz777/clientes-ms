using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteGrupoEmpresaHandler : IRequestHandler<DeleteGrupoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    public DeleteGrupoEmpresaHandler(IBaseRepository<GrupoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteGrupoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdGrupoEmpresa);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}