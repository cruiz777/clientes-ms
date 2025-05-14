using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteHistorialClienteHandler : IRequestHandler<DeleteHistorialClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;
    public DeleteHistorialClienteHandler(IBaseRepository<HistorialCliente> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteHistorialClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdHistorialCliente);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}