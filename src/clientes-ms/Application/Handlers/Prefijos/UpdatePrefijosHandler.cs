using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdatePrefijosHandler : IRequestHandler<UpdatePrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public UpdatePrefijosHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdatePrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdPrefijos);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"Prefijos with ID {request.IdPrefijos} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Codpre = request.Request.Codpre.Trim();
            existing.Fecha = request.Request.Fecha;
            existing.FechaCierre = request.Request.FechaCierre;
            existing.Observacion = request.Request.Observacion.Trim();
            existing.Digitos = request.Request.Digitos.Trim();
            existing.Estado = request.Request.Estado;
            existing.Control = request.Request.Control;
            existing.Ngln = request.Request.Ngln;
            existing.Bandera = request.Request.Bandera;
            existing.Facturar = request.Request.Facturar.Trim();
            existing.Codpro = request.Request.Codpro.Trim();
            existing.Nombre = request.Request.Nombre.Trim();
            existing.Fecfac = request.Request.Fecfac.Trim();
            existing.ReferenciaInterna = request.Request.ReferenciaInterna.Trim();
            existing.Prefijosgs1 = request.Request.Prefijosgs1.Trim();
            existing.OrigenPrefijo=request.Request.OrigenPrefijo.Trim();
            existing.Orden = request.Request.Orden;
            existing.ClientesCodigo = request.Request.ClientesCodigo;


            await _repository.UpdateAsync(request.IdPrefijos, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Updated successfully"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "ERROR",
                false,
                ex.Message
            );
        }
    }
}
