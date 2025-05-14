using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateTipoClienteHandler : IRequestHandler<CreateTipoClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<TipoCliente> _repository;
    private readonly ITipoClienteDomainService _domainService;

    public CreateTipoClienteHandler(
        IBaseRepository<TipoCliente> repository,
        ITipoClienteDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<ApiResponse<bool>> Handle(CreateTipoClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _domainService.DescripcionYaExisteAsync(request.Request.Descripcion))
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "VALIDATION", false, "Ya existe un tipo de cliente con esa descripción.");
            }

            var entity = new TipoCliente
            {
                Descripcion = request.Request.Descripcion.Trim(),
                IdEmpresa = request.Request.IdEmpresa,
                Cuenta = request.Request.Cuenta,
                Estado = request.Request.Estado
            };

            await _repository.AddAsync(entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
