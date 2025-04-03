using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteEstadoEmpresaHandler : IRequestHandler<DeleteEstadoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<EstadoEmpresa> _repository;
    public DeleteEstadoEmpresaHandler(IBaseRepository<EstadoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteEstadoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdEstadoEmpresa);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}