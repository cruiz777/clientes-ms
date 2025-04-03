using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateCiudadesHandler : IRequestHandler<CreateCiudadesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public CreateCiudadesHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateCiudadesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Ciudades { Referencia = request.Request.Referencia.Trim(), Nombre = request.Request.Nombre.Trim(),IdCanton=request.Request.IdCanton };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}