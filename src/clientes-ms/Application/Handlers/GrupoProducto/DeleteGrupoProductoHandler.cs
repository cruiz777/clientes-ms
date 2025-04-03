using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteGrupoProductoHandler : IRequestHandler<DeleteGrupoProductoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    public DeleteGrupoProductoHandler(IBaseRepository<GrupoProducto> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteGrupoProductoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdGrupoProducto);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}