using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteTipoClienteHandler : IRequestHandler<DeleteTipoClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    public DeleteTipoClienteHandler(IBaseRepository<TipoCliente> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteTipoClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdTipoCliente);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}