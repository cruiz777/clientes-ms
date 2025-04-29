using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateGlnHandler : IRequestHandler<UpdateGlnCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Gln> _repository;
    public UpdateGlnHandler(IBaseRepository<Gln> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(UpdateGlnCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"Gln with ID {request.Id} not found."
                );
            }

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            
            existing.IdPrefijos = request.Request.IdPrefijos;
            existing.ClientesCodigo = request.Request.ClientesCodigo;
            existing.Gln1 = request.Request.Gln1?.Trim();
            existing.IdTipoLocalizacion = request.Request.IdTipoLocalizacion;
            existing.GlnLatitud = request.Request.GlnLatitud?.Trim();
            existing.GlnLongitud = request.Request.GlnLongitud?.Trim();
            existing.IdPais = request.Request.IdPais;
            existing.Direccion = request.Request.Direccion?.Trim();
            existing.Telefono = request.Request.Telefono?.Trim();
            existing.Fax = request.Request.Fax?.Trim();
            existing.Contacto = request.Request.Contacto?.Trim();
            existing.ContactoTel = request.Request.ContactoTel?.Trim();
            existing.Email = request.Request.Email?.Trim();
            existing.Web = request.Request.Web?.Trim();
            existing.Fda = request.Request.Fda?.Trim();
            existing.Europa = request.Request.Europa?.Trim();
            existing.GlnGlobal = request.Request.GlnGlobal?.Trim();
            existing.GlnFecha = request.Request.GlnFecha;
            existing.IdCiudad = request.Request.IdCiudad;
            existing.GlnCodigopostal = request.Request.GlnCodigopostal?.Trim();
            existing.GlnCelular = request.Request.GlnCelular?.Trim();
            existing.GlnContacto2 = request.Request.GlnContacto2?.Trim();
            existing.GlnEmail2 = request.Request.GlnEmail2?.Trim();
            existing.GlnTel2 = request.Request.GlnTel2?.Trim();
            existing.GlnContacto3 = request.Request.GlnContacto3?.Trim();
            existing.GlnEmail3 = request.Request.GlnEmail3?.Trim();
            existing.GlnTel3 = request.Request.GlnTel3?.Trim();
            existing.GlnFacturar = request.Request.GlnFacturar?.Trim();
            existing.GlnCodpro = request.Request.GlnCodpro?.Trim();
            existing.GlnNombre = request.Request.GlnNombre?.Trim();
            existing.GlnOtro1 = request.Request.GlnOtro1?.Trim();
            existing.GlnOtro2 = request.Request.GlnOtro2?.Trim();
            existing.GlnObs1 = request.Request.GlnObs1?.Trim();
            existing.GlnObs2 = request.Request.GlnObs2?.Trim();
            existing.GlnOrigenprefijo = request.Request.GlnOrigenprefijo?.Trim();
            existing.GlnPrefijogs1 = request.Request.GlnPrefijogs1?.Trim();
            existing.GlnGlnp = request.Request.GlnGlnp?.Trim();
            existing.GlnGlne = request.Request.GlnGlne?.Trim();
            existing.NombreLocalizacion = request.Request.NombreLocalizacion?.Trim();
            existing.Observ = request.Request.Observ?.Trim();
            existing.Expprod = request.Request.Expprod;
            existing.Gs1ec = request.Request.Gs1ec;
            existing.Gs1latam = request.Request.Gs1latam;
            existing.Gas1org = request.Request.Gas1org;
            existing.Google = request.Request.Google;
            existing.Gs1otros = request.Request.Gs1otros?.Trim();
            existing.LongG = request.Request.LongG?.Trim();
            existing.LongM = request.Request.LongM?.Trim();
            existing.LongS = request.Request.LongS?.Trim();
            existing.LongE = request.Request.LongE?.Trim();
            existing.LatiG = request.Request.LatiG?.Trim();
            existing.LatiM = request.Request.LatiM?.Trim();
            existing.LatiS = request.Request.LatiS?.Trim();
            existing.LatiE = request.Request.LatiE?.Trim();
            existing.IdUsuario = request.Request.IdUsuario;

            await _repository.UpdateAsync(request.Id, existing);

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
