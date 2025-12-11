using clientes_ms.Application.Orchestators;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Infrastructure.Persistence.Context;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace clientes_ms.Application.Handlers.Cliente;

public class CreateClientesHandler : IRequestHandler<CreateClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Clientes> _repository;
    private readonly PersonaOrquestadorService _personaOrquestador;
    private readonly ApplicationDbContext _context;

    public CreateClientesHandler(
        IBaseRepository<Clientes> repository,
        PersonaOrquestadorService personaOrquestador,
        ApplicationDbContext context)
    {
        _repository = repository;
        _personaOrquestador = personaOrquestador;
        _context = context;
    }

    public async Task<ApiResponse<bool>> Handle(CreateClientesCommand request, CancellationToken cancellationToken)
    {
        IDbContextTransaction? transaction = null;
        
        try
        {
            PersonaOrquestadorService.PersonaConDatos personaConDatos;

            // 1. Crear o obtener persona (fuera de la transacción porque tiene su propio SaveChanges)
            if (request.Request.IdPersona == 0)
            {
                personaConDatos = await _personaOrquestador.CrearPersonaDesdeClienteAsync(request.Request);
            }
            else
            {
                var personaExistente = await _context.Personas.AsNoTracking()
                    .FirstOrDefaultAsync(p => p.IdPersona == request.Request.IdPersona, cancellationToken);

                if (personaExistente == null)
                    throw new Exception("La persona especificada no existe.");

                personaConDatos = new PersonaOrquestadorService.PersonaConDatos(
                    personaExistente.IdPersona,
                    personaExistente.Nombre1,
                    personaExistente.Nombre2,
                    personaExistente.Apellido1,
                    personaExistente.Apellido2,
                    personaExistente.TipoPersona,
                    personaExistente.IdTipoDocumento,
                    null,
                    null,
                    personaExistente.FechaNacimiento,
                    null,
                    null
                );
            }

            // 2. Iniciar transacción para Cliente + CodigosContables
            transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            // 3. Crear el cliente
            var cliente = new Clientes
            {
                IdPersona = personaConDatos.IdPersona,
                Nomcli = request.Request.Nomcli?.Trim(),
                Dircli = request.Request.Dircli?.Trim(),
                Concli = request.Request.Concli?.Trim(),
                Email = request.Request.Email?.Trim(),
                Telefono = request.Request.Telefono?.Trim(),
                Telefono1 = request.Request.Telefono1?.Trim(),
                RazonSocial = request.Request.RazonSocial?.Trim(),
                Fax = request.Request.Fax?.Trim(),
                Ruc = request.Request.Ruc?.Trim(),
                Fecing = request.Request.Fecing,
                Fecnac = request.Request.Fecnac,
                FechaCeseAct = request.Request.FechaCeseActParsed,
                MotivoCeseAct = request.Request.MotivoCeseAct,
                Fecfac1 = request.Request.Fecfac1,
                Fecfac2 = request.Request.Fecfac2,
                Fecfac3 = request.Request.Fecfac3,
                Fecfac4 = request.Request.Fecfac4,
                Fecfac5 = request.Request.Fecfac5,
                Marca1 = request.Request.Marca1?.Trim(),
                Marca2 = request.Request.Marca2?.Trim(),
                Marca3 = request.Request.Marca3?.Trim(),
                Marca4 = request.Request.Marca4?.Trim(),
                Marca5 = request.Request.Marca5?.Trim(),
                Codcue = request.Request.Codcue?.Trim(),
                Hello = request.Request.Hello?.Trim(),
                Desde = request.Request.Desde,
                Fechtre = request.Request.Fechtre,
                Web = request.Request.Web?.Trim(),
                Saldo = request.Request.Saldo,
                Fecfac = request.Request.Fecfac?.Trim(),
                Ciudad = request.Request.Ciudad?.Trim(),
                Obs = request.Request.Obs?.Trim(),
                Delestado = request.Request.Delestado,
                Genero = request.Request.Genero?.Trim(),
                Infcamahabitacion = request.Request.Infcamahabitacion?.Trim(),
                EmpresaCodigo = request.Request.EmpresaCodigo,
                Seguimiento = request.Request.Seguimiento,
                Fechaactinact = request.Request.Fechaactinact,
                IdEstadoEmpresa = request.Request.IdEstadoEmpresa,
                Formatodocumento = request.Request.Formatodocumento,
                Imprimeobstramite = request.Request.Imprimeobstramite,
                IdTipoCliente = request.Request.IdTipoCliente,
                IdGrupoProducto = request.Request.IdGrupoProducto,
                CodigoPostal = request.Request.CodigoPostal?.Trim(),
                CodigoPostal2 = request.Request.CodigoPostal2?.Trim(),
                IdVendedor = request.Request.IdVendedor,
                IdCiudad = request.Request.IdCiudad,
                IdZona = request.Request.IdZona,
                IdGrupoEmpresa = request.Request.IdGrupoEmpresa,
                Representante = request.Request.Representante?.Trim(),
                Fecmod = request.Request.Fecmod,
                Usumod = request.Request.Usumod
            };

            await _repository.AddAsync(cliente);

            // 4. Verificar y crear CodigosContables si no existe
            var yaExisteEnCodigosContables = await _context.CodigosContables.AsNoTracking()
                .AnyAsync(c => c.IdPersona == personaConDatos.IdPersona, cancellationToken);

            if (!yaExisteEnCodigosContables)
            {
                if (!request.Request.EmpresaCodigo.HasValue)
                    throw new Exception("EmpresaCodigo es requerido para crear el código contable.");

                var codigoContable = new CodigosContables
                {
                    IdPersona = personaConDatos.IdPersona,
                    Nombre1 = personaConDatos.Nombre1,
                    Nombre2 = personaConDatos.Nombre2,
                    Apellido1 = personaConDatos.Apellido1,
                    Apellido2 = personaConDatos.Apellido2,
                    Tipopersona = DeterminarTipoPersonaPorDigitos(request.Request.Ruc),
                    Tipoidentificacion = (int?)personaConDatos.IdTipoDocumento,
                    Identificacionauxiliar = request.Request.Ruc?.Trim(),
                    Nombreauxiliar = request.Request.Nomcli?.Trim() ?? request.Request.RazonSocial?.Trim(),
                    Direccionauxiliar = request.Request.Dircli?.Trim(),
                    Telefonoauxiliar = request.Request.Telefono?.Trim(),
                    Celularauxiliar = request.Request.Telefono1?.Trim(),
                    Emailauxiliar = request.Request.Email?.Trim(),
                    Razonsocial = request.Request.RazonSocial?.Trim(),
                    ActividadComercial = personaConDatos.ActividadComercial?.Trim(),
                    EstadoRuc = personaConDatos.EstadoRuc,
                    FechaInicioAct = personaConDatos.FechaInicioActividades,
                    IdCiudad = request.Request.IdCiudad,
                    IdEmpresa = request.Request.EmpresaCodigo.Value,
                    IdUsuario = request.Request.IdUsuario ?? 1,
                    IdTipoContribuyente = MapTipoContribuyente(
                        personaConDatos.IdTipoDocumento,
                        personaConDatos.Regimen,
                        personaConDatos.ContribuyenteEspecial
                    ),
                    Plazo = null,
                    Parterelacionada = 0,
                    Estado = true,
                    FechaRegistro = DateTime.Now
                };

                await _context.CodigosContables.AddAsync(codigoContable, cancellationToken);
            }

            // 5. Guardar todos los cambios
            await _context.SaveChangesAsync(cancellationToken);

            // 6. Commit de la transacción
            await transaction.CommitAsync(cancellationToken);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Cliente creado correctamente");
        }
        catch (Exception ex)
        {
            // 7. Rollback automático si hay error
            if (transaction != null)
            {
                await transaction.RollbackAsync(cancellationToken);
            }

            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
        finally
        {
            // 8. Liberar recursos
            transaction?.Dispose();
        }
    }
    private static string? DeterminarTipoPersonaPorDigitos(string? identificacion)
    {
        if (string.IsNullOrWhiteSpace(identificacion))
            return "01"; // Default para cédula/pasaporte

        var digitos = identificacion.Trim().Length;

        return digitos == 13 ? "02" : "01"; // 13 dígitos = RUC, 10 dígitos = Cédula/Pasaporte
    }

    /// <summary>
    /// Mapea a tipo de contribuyente según datos del SRI.
    /// Prioriza: Contribuyente Especial > Régimen específico > Default
    /// </summary>
    private static long MapTipoContribuyente(
        long idTipoDocumento,
        string? regimen,
        string? contribuyenteEspecial)
    {
        if (idTipoDocumento == 3)
        {
            if (contribuyenteEspecial?.ToUpper() == "SI")
                return 4;

            if (!string.IsNullOrWhiteSpace(regimen))
            {
                var regimenUpper = regimen.ToUpper();

                if (regimenUpper.Contains("RIMPE"))
                {
                    if (regimenUpper.Contains("NEGOCIO POPULAR"))
                        return 1;

                    if (regimenUpper.Contains("EMPRENDEDOR"))
                        return 2;
                }
            }
        }

        return 3;
    }
}