using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateTipoLocalizacionHandler : IRequestHandler<CreateTipoLocalizacionCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    private readonly ITipoLocalizacionDomainService _domainService;

    public CreateTipoLocalizacionHandler(
        IBaseRepository<TipoLocalizacion> repository,
        ITipoLocalizacionDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<ApiResponse<bool>> Handle(CreateTipoLocalizacionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Validar duplicado de descripción
            if (await _domainService.DescripcionYaExisteAsync(request.Request.Descripcion))
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un tipo de localización con esa descripción.");
            }

            var entity = new TipoLocalizacion
            {
                Descripcion = request.Request.Descripcion.Trim(),
                Estado = request.Request.Estado
            };

            await _repository.AddAsync(entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Creado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
