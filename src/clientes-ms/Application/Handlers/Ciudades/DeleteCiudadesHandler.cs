using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteCiudadesHandler : IRequestHandler<DeleteCiudadesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public DeleteCiudadesHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteCiudadesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdCiudad);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}