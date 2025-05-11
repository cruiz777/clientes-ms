using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteAuditoriaTransferenciaHandler : IRequestHandler<DeleteAuditoriaTransferenciaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;
    public DeleteAuditoriaTransferenciaHandler(IBaseRepository<AuditoriaTransferencia> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteAuditoriaTransferenciaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdAuditoriaTransferencia);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}