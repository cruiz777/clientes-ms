using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateHistorialClienteHandler : IRequestHandler<CreateHistorialClienteCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<HistorialCliente> _repository;
    public CreateHistorialClienteHandler(IBaseRepository<HistorialCliente> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateHistorialClienteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new HistorialCliente { 

                IdUsuario=request.Request.IdUsuario,NombreUsuario=request.Request.NombreUsuario,
                Fecha=request.Request.Fecha,Descripcion = request.Request.Descripcion.Trim(),ClientesCodigo=request.Request.ClientesCodigo 
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