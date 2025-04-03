using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteZonaHandler : IRequestHandler<DeleteZonaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Zona> _repository;
    public DeleteZonaHandler(IBaseRepository<Zona> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteZonaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdZona);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}