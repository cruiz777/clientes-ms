using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteContactosClientesHandler : IRequestHandler<DeleteContactosClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;
    public DeleteContactosClientesHandler(IBaseRepository<ContactosClientes> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteContactosClientesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdContactosClientes);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}