using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteClienteObservacionHandler : IRequestHandler<DeleteClienteObservacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;
    public DeleteClienteObservacionHandler(IBaseRepository<ClienteObservacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteClienteObservacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdClienteObservacion);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}