using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateContactosClientesHandler : IRequestHandler<CreateContactosClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ContactosClientes> _repository;
    public CreateContactosClientesHandler(IBaseRepository<ContactosClientes> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateContactosClientesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new ContactosClientes { Nombre = request.Request.Nombre.Trim(), Telefono = request.Request.Telefono.Trim(), Email = request.Request.Email.Trim(), Cargo = request.Request.Cargo.Trim(), ClientesCodigo=request.Request.ClientesCodigo };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}