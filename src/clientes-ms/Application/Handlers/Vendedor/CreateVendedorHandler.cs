using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateVendedorHandler : IRequestHandler<CreateVendedorCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Vendedor> _repository;
    public CreateVendedorHandler(IBaseRepository<Vendedor> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateVendedorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Vendedor { Nombre = request.Request.Nombre.Trim(), Ruc = request.Request.Ruc.Trim(), PorVendedor = request.Request.PorVendedor.Trim(), Fecing = request.Request.Fecing, Fecsal = request.Request.Fecsal, Estado=request.Request.Estado,EmpresaCodigo = request.Request.EmpresaCodigo };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}