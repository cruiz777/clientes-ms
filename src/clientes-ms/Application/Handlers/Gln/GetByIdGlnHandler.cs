using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGlnByIdHandler : IRequestHandler<GetGlnByIdQuery, ApiResponse<GlnResponse>>
{
    private readonly IBaseRepository<Gln> _repository;

    public GetGlnByIdHandler(IBaseRepository<Gln> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<GlnResponse>> Handle(GetGlnByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return new ApiResponse<GlnResponse>(
                    Guid.NewGuid(),
                    "OBJECT",
                    null,
                    $"GLN con ID {request.Id} no encontrado."
                );
            }

            var response = MapToResponse(entity);

            return new ApiResponse<GlnResponse>(
                Guid.NewGuid(),
                "OBJECT",
                response,
                "Success"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<GlnResponse>(
                Guid.NewGuid(),
                "ERROR",
                null,
                ex.Message
            );
        }
    }

    private static GlnResponse MapToResponse(Gln e) => new GlnResponse(
        e.IdGln,
        e.IdPrefijos,
        e.ClientesCodigo,
        e.Gln1?.Trim() ?? string.Empty,
        e.IdTipoLocalizacion,
        e.GlnLatitud?.Trim() ?? string.Empty,
        e.GlnLongitud?.Trim() ?? string.Empty,
        e.IdPais,
        e.Direccion?.Trim() ?? string.Empty,
        e.Telefono?.Trim() ?? string.Empty,
        e.Fax?.Trim() ?? string.Empty,
        e.Contacto?.Trim() ?? string.Empty,
        e.ContactoTel?.Trim() ?? string.Empty,
        e.Email?.Trim() ?? string.Empty,
        e.Web?.Trim() ?? string.Empty,
        e.Fda?.Trim() ?? string.Empty,
        e.Europa?.Trim() ?? string.Empty,
        e.GlnGlobal?.Trim() ?? string.Empty,
        e.GlnFecha,
        e.IdCiudad,
        e.GlnCodigopostal?.Trim() ?? string.Empty,
        e.GlnCelular?.Trim() ?? string.Empty,
        e.GlnContacto2?.Trim() ?? string.Empty,
        e.GlnEmail2?.Trim() ?? string.Empty,
        e.GlnTel2?.Trim() ?? string.Empty,
        e.GlnContacto3?.Trim() ?? string.Empty,
        e.GlnEmail3?.Trim() ?? string.Empty,
        e.GlnTel3?.Trim() ?? string.Empty,
        e.GlnFacturar?.Trim() ?? string.Empty,
        e.GlnCodpro?.Trim() ?? string.Empty,
        e.GlnNombre?.Trim() ?? string.Empty,
        e.GlnOtro1?.Trim() ?? string.Empty,
        e.GlnOtro2?.Trim() ?? string.Empty,
        e.GlnObs1?.Trim() ?? string.Empty,
        e.GlnObs2?.Trim() ?? string.Empty,
        e.GlnOrigenprefijo?.Trim() ?? string.Empty,
        e.GlnPrefijogs1?.Trim() ?? string.Empty,
        e.GlnGlnp?.Trim() ?? string.Empty,
        e.GlnGlne?.Trim() ?? string.Empty,
        e.NombreLocalizacion?.Trim() ?? string.Empty,
        e.Observ?.Trim() ?? string.Empty,
        e.Expprod,
        e.Gs1ec,
        e.Gs1latam,
        e.Gas1org,
        e.Google,
        e.Gs1otros?.Trim() ?? string.Empty,
        e.LongG?.Trim() ?? string.Empty,
        e.LongM?.Trim() ?? string.Empty,
        e.LongS?.Trim() ?? string.Empty,
        e.LongE?.Trim() ?? string.Empty,
        e.LatiG?.Trim() ?? string.Empty,
        e.LatiM?.Trim() ?? string.Empty,
        e.LatiS?.Trim() ?? string.Empty,
        e.LatiE?.Trim() ?? string.Empty,
        e.IdUsuario
    );
}
