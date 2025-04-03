using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteSectorHandler : IRequestHandler<DeleteSectorCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Sector> _repository;
    public DeleteSectorHandler(IBaseRepository<Sector> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdSector);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}