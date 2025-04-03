using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateZonaHandler : IRequestHandler<CreateZonaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Zona> _repository;
    public CreateZonaHandler(IBaseRepository<Zona> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateZonaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Zona {
                Referencia = request.Request.Referencia.Trim(),
                Nombre = request.Request.Nombre.Trim(),
                Numero = request.Request.Numero.Trim(),
                EmpresaCodigo = request.Request.EmpresaCodigo
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