using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateTipoLocalizacionHandler : IRequestHandler<CreateTipoLocalizacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    public CreateTipoLocalizacionHandler(IBaseRepository<TipoLocalizacion> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateTipoLocalizacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new TipoLocalizacion { Descripcion = request.Request.Descripcion.Trim(),Estado=request.Request.Estado };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}