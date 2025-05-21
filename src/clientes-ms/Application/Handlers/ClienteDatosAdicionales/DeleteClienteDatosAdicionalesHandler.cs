using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteClienteDatosAdicionalesHandler : IRequestHandler<DeleteClienteDatosAdicionalesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;
    public DeleteClienteDatosAdicionalesHandler(IBaseRepository<ClienteDatosAdicionales> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteClienteDatosAdicionalesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdClienteDatosAdicionales);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}