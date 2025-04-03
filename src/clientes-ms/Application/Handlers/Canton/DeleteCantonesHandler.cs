using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteCantonHandler : IRequestHandler<DeleteCantonesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Cantones> _repository;
    public DeleteCantonHandler(IBaseRepository<Cantones> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteCantonesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdCanton);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}