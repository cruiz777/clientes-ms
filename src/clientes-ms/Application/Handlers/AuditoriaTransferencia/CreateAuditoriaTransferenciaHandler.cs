using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateAuditoriaTransferenciaHandler : IRequestHandler<CreateAuditoriaTransferenciaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;
    public CreateAuditoriaTransferenciaHandler(IBaseRepository<AuditoriaTransferencia> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateAuditoriaTransferenciaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new AuditoriaTransferencia { 
                ClientesCodigoOrigen=request.Request.ClientesCodigoOrigen,
                ClientesCodigoDestino=request.Request.ClientesCodigoDestino,
                Fecha = request.Request.Fecha,
                IdPrefijos=request.Request.IdPrefijos,
                IdUsuario=request.Request.IdUsuario,
                Tipo = request.Request.Tipo
                
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