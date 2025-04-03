using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateProvinciaHandler : IRequestHandler<CreateProvinciaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Provincia> _repository;
    public CreateProvinciaHandler(IBaseRepository<Provincia> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateProvinciaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Provincia { Referencia = request.Request.Referencia.Trim(), Nombre = request.Request.Nombre.Trim(),IdPais=request.Request.IdPais };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}