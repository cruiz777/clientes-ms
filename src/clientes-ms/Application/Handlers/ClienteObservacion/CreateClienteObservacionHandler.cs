using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateClienteObservacionHandler : IRequestHandler<CreateClienteObservacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;
    public CreateClienteObservacionHandler(IBaseRepository<ClienteObservacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateClienteObservacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new ClienteObservacion { Detalle = request.Request.Detalle?.Trim(), Fecha = request.Request.Fecha, IdUsuario = request.Request.IdUsuario, ClientesCodigo = request.Request.ClientesCodigo };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}