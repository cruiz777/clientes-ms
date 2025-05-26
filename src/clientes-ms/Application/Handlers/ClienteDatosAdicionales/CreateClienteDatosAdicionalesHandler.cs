using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Domain.Interfaces.IDomainServices;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateClienteDatosAdicionalesHandler : IRequestHandler<CreateClienteDatosAdicionalesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;

    public CreateClienteDatosAdicionalesHandler(IBaseRepository<ClienteDatosAdicionales> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(CreateClienteDatosAdicionalesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new ClienteDatosAdicionales
            {
                Expprod = request.Request.Expprod,
                Vendeus = request.Request.Vendeus,
                Medico = request.Request.Medico,
                Gs1ec = request.Request.Gs1ec,
                Instagram = request.Request.Instagram,
                Facebook = request.Request.Facebook,
                Web = request.Request.Web,
                ClientesCodigo = request.Request.ClientesCodigo,
                Prefijo = request.Request.Prefijo,
                Guia = request.Request.Guia,
                Estado = request.Request.Estado
            };

            await _repository.AddAsync(entity);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Datos adicionales creados correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
