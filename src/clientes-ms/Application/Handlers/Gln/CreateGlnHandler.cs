using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateGlnHandler : IRequestHandler<CreateGlnCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Gln> _repository;
    public CreateGlnHandler(IBaseRepository<Gln> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateGlnCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Gln {
                IdPrefijos = request.Request.IdPrefijos,
                ClientesCodigo = request.Request.ClientesCodigo,
                Gln1 = request.Request.Gln1?.Trim(),
                IdTipoLocalizacion = request.Request.IdTipoLocalizacion,
                GlnLatitud = request.Request.GlnLatitud?.Trim(),
                GlnLongitud = request.Request.GlnLongitud?.Trim(),
                IdPais = request.Request.IdPais,
                Direccion = request.Request.Direccion?.Trim(),
                Telefono = request.Request.Telefono?.Trim(),
                Fax = request.Request.Fax?.Trim(),
                Contacto = request.Request.Contacto?.Trim(),
                ContactoTel = request.Request.ContactoTel?.Trim(),
                Email = request.Request.Email?.Trim(),
                Web = request.Request.Web?.Trim(),
                Fda = request.Request.Fda?.Trim(),
                Europa = request.Request.Europa?.Trim(),
                GlnGlobal = request.Request.GlnGlobal?.Trim(),
                GlnFecha = request.Request.GlnFecha,
                IdCiudad = request.Request.IdCiudad,
                GlnCodigopostal = request.Request.GlnCodigopostal?.Trim(),
                GlnCelular = request.Request.GlnCelular?.Trim(),
                GlnContacto2 = request.Request.GlnContacto2?.Trim(),
                GlnEmail2 = request.Request.GlnEmail2?.Trim(),
                GlnTel2 = request.Request.GlnTel2?.Trim(),
                GlnContacto3 = request.Request.GlnContacto3?.Trim(),
                GlnEmail3 = request.Request.GlnEmail3?.Trim(),
                GlnTel3 = request.Request.GlnTel3?.Trim(),
                GlnFacturar = request.Request.GlnFacturar?.Trim(),
                GlnCodpro = request.Request.GlnCodpro?.Trim(),
                GlnNombre = request.Request.GlnNombre?.Trim(),
                GlnOtro1 = request.Request.GlnOtro1?.Trim(),
                GlnOtro2 = request.Request.GlnOtro2?.Trim(),
                GlnObs1 = request.Request.GlnObs1?.Trim(),
                GlnObs2 = request.Request.GlnObs2?.Trim(),
                GlnOrigenprefijo = request.Request.GlnOrigenprefijo?.Trim(),
                GlnPrefijogs1 = request.Request.GlnPrefijogs1?.Trim(),
                GlnGlnp = request.Request.GlnGlnp?.Trim(),
                GlnGlne = request.Request.GlnGlne?.Trim(),
                NombreLocalizacion = request.Request.NombreLocalizacion?.Trim(),
                Observ = request.Request.Observ?.Trim(),
                Expprod = request.Request.Expprod,
                Gs1ec = request.Request.Gs1ec,
                Gs1latam = request.Request.Gs1latam,
                Gas1org = request.Request.Gas1org,
                Google = request.Request.Google,
                Gs1otros = request.Request.Gs1otros?.Trim(),
                LongG = request.Request.LongG?.Trim(),
                LongM = request.Request.LongM?.Trim(),
                LongS = request.Request.LongS?.Trim(),
                LongE = request.Request.LongE?.Trim(),
                LatiG = request.Request.LatiG?.Trim(),
                LatiM = request.Request.LatiM?.Trim(),
                LatiS = request.Request.LatiS?.Trim(),
                LatiE = request.Request.LatiE?.Trim(),
                IdUsuario = request.Request.IdUsuario
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