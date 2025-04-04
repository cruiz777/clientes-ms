using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeletePrefijosHandler : IRequestHandler<DeletePrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public DeletePrefijosHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeletePrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdPrefijos);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}