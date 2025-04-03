using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteVendedorHandler : IRequestHandler<DeleteVendedorCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Vendedor> _repository;
    public DeleteVendedorHandler(IBaseRepository<Vendedor> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteVendedorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdVendedor);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}