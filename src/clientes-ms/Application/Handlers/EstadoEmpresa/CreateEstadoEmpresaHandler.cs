using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateEstadoEmpresaHandler : IRequestHandler<CreateEstadoEmpresaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<EstadoEmpresa> _repository;
    public CreateEstadoEmpresaHandler(IBaseRepository<EstadoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateEstadoEmpresaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new EstadoEmpresa { Nombre = request.Request.Nombre.Trim(), Fecha = request.Request.Fecha,EmpresaCodigo=request.Request.EmpresaCodigo };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}