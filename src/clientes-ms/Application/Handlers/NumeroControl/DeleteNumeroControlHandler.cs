using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteNumeroControlHandler : IRequestHandler<DeleteNumeroControlCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<NumeroControl> _repository;
    public DeleteNumeroControlHandler(IBaseRepository<NumeroControl> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteNumeroControlCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdNumeroControl);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}