using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteTipoLocalizacionHandler : IRequestHandler<DeleteTipoLocalizacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    public DeleteTipoLocalizacionHandler(IBaseRepository<TipoLocalizacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteTipoLocalizacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdTipoLocalizacion);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}