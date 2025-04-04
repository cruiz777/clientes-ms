using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreatePrefijosHandler : IRequestHandler<CreatePrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public CreatePrefijosHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreatePrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Prefijos {
                Codpre = request.Request.Codpre.Trim(),
                Fecha = request.Request.Fecha,
                FechaCierre = request.Request.FechaCierre,
                Observacion = request.Request.Observacion.Trim(),
                Digitos = request.Request.Digitos.Trim(),
                Estado = request.Request.Estado,
                Control = request.Request.Control,
                Ngln = request.Request.Ngln,
                Bandera = request.Request.Bandera,
                Facturar = request.Request.Facturar.Trim(),
                Codpro = request.Request.Codpro.Trim(),
                Nombre = request.Request.Nombre.Trim(),
                Fecfac = request.Request.Fecfac.Trim(),
                ReferenciaInterna = request.Request.ReferenciaInterna.Trim(),
                Prefijosgs1 = request.Request.Prefijosgs1.Trim(),
                OrigenPrefijo = request.Request.OrigenPrefijo.Trim(),
                Orden = request.Request.Orden,
                ClientesCodigo=request.Request.ClientesCodigo

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