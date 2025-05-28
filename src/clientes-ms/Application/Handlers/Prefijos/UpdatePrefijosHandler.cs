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
            //if (!string.IsNullOrWhiteSpace(request.Request.Codpre))
            //    existing.Codpre = request.Request.Codpre.Trim();

            //if (request.Request.Fecha != null)
            //    existing.Fecha = request.Request.Fecha;

            
                existing.FechaCierre = request.Request.FechaCierre;

            
                existing.Observacion = request.Request.Observacion;

            //if (!string.IsNullOrWhiteSpace(request.Request.Digitos))
            //    existing.Digitos = request.Request.Digitos.Trim();

            if (request.Request.Estado != null)
                existing.Estado = request.Request.Estado;

            //if (request.Request.Control != null)
            //    existing.Control = request.Request.Control;

            //if (request.Request.Ngln != null)
            //    existing.Ngln = request.Request.Ngln;

            //if (request.Request.Bandera != null)
            //    existing.Bandera = request.Request.Bandera;

            //if (!string.IsNullOrWhiteSpace(request.Request.Facturar))
            //    existing.Facturar = request.Request.Facturar.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Codpro))
            //    existing.Codpro = request.Request.Codpro.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Nombre))
            //    existing.Nombre = request.Request.Nombre.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Fecfac))
            //    existing.Fecfac = request.Request.Fecfac.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.ReferenciaInterna))
            //    existing.ReferenciaInterna = request.Request.ReferenciaInterna.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Prefijosgs1))
            //    existing.Prefijosgs1 = request.Request.Prefijosgs1.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.OrigenPrefijo))
            //    existing.OrigenPrefijo = request.Request.OrigenPrefijo.Trim();

            //if (request.Request.Orden != null)
            //    existing.Orden = request.Request.Orden;

            if (request.Request.ClientesCodigo != null)
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
