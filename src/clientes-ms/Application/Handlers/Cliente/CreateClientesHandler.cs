using System;
using System.Threading;
using System.Threading.Tasks;
using clientes_ms.Application.Orchestators;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using clientes_ms.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class CreateClientesHandler : IRequestHandler<CreateClientesCommand, ApiResponse<long>>
    {
        private readonly PersonaOrquestadorService _personaOrquestador;
        private readonly ApplicationDbContext _context;

        public CreateClientesHandler(
            PersonaOrquestadorService personaOrquestador,
            ApplicationDbContext context)
        {
            _personaOrquestador = personaOrquestador;
            _context = context;
        }

        public async Task<ApiResponse<long>> Handle(CreateClientesCommand request, CancellationToken cancellationToken)
        {
            IDbContextTransaction? transaction = null;

            try
            {
                PersonaOrquestadorService.PersonaConDatos personaConDatos;

                // 1) Persona (fuera de transacción)
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
                        null, null,
                        personaExistente.FechaNacimiento,
                        null, null
                    );
                }

                // 2) Transacción
                transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

                // 3) Cliente
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
                    Fechtre = request.Request.Fechtre,
                    Web = request.Request.Web?.Trim(),
                    Saldo = request.Request.Saldo,
                    Ciudad = request.Request.Ciudad?.Trim(),
                    EmpresaCodigo = request.Request.EmpresaCodigo,
                    IdEstadoEmpresa = request.Request.IdEstadoEmpresa,
                    IdTipoCliente = request.Request.IdTipoCliente,
                    IdGrupoProducto = request.Request.IdGrupoProducto,
                    CodigoPostal = request.Request.CodigoPostal?.Trim(),
                    IdVendedor = request.Request.IdVendedor,
                    IdCiudad = request.Request.IdCiudad,
                    IdZona = request.Request.IdZona,
                    IdGrupoEmpresa = request.Request.IdGrupoEmpresa,
                    Representante = request.Request.Representante?.Trim(),
                    Fecmod = request.Request.Fecmod,
                    Usumod = request.Request.Usumod
                };

                await _context.Clientes.AddAsync(cliente, cancellationToken);

                // 4) CodigosContables (si no existe)
                var yaExisteEnCodigosContables = await _context.CodigosContables.AsNoTracking()
                    .AnyAsync(c => c.IdPersona == personaConDatos.IdPersona, cancellationToken);

                if (!yaExisteEnCodigosContables)
                {
                    if (!request.Request.EmpresaCodigo.HasValue)
                        throw new Exception("EmpresaCodigo es requerido para crear el código contable.");

                    const long idTipoContribuyenteDefault = 3; // ✅ SIEMPRE 3 (Régimen General)

                    // ✅ Validación preventiva (evita FK 547 si no existe el 3)
                    var existeTipo = await _context.TipoContribuyente.AsNoTracking()
                        .AnyAsync(t => t.IdTipoContribuyente == idTipoContribuyenteDefault, cancellationToken);

                    if (!existeTipo)
                        throw new Exception($"No existe IdTipoContribuyente={idTipoContribuyenteDefault} en cg.TipoContribuyente.");

                    var codigoContable = new CodigosContables
                    {
                        IdPersona = personaConDatos.IdPersona,
                        Identificacionauxiliar = request.Request.Ruc?.Trim(),
                        Nombreauxiliar = request.Request.Nomcli?.Trim() ?? request.Request.RazonSocial?.Trim(),
                        Direccionauxiliar = request.Request.Dircli?.Trim(),
                        Telefonoauxiliar = request.Request.Telefono?.Trim(),
                        Celularauxiliar = request.Request.Telefono1?.Trim(),
                        Emailauxiliar = request.Request.Email?.Trim(),
                        Razonsocial = request.Request.RazonSocial?.Trim(),
                        IdCiudad = request.Request.IdCiudad,
                        IdEmpresa = request.Request.EmpresaCodigo.Value,
                        IdUsuario = request.Request.IdUsuario ?? 1,
                        Estado = true,
                        FechaRegistro = DateTime.Now,

                        // ✅ FK REAL EN TU ENTIDAD
                        IdTipoContribuyente = idTipoContribuyenteDefault
                    };

                    await _context.CodigosContables.AddAsync(codigoContable, cancellationToken);
                }

                // 5) Save + Commit
                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new ApiResponse<long>(Guid.NewGuid(), "LONG", cliente.ClientesCodigo, "Cliente creado correctamente");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    await transaction.RollbackAsync(cancellationToken);

                return ApiResponse<long>.Error(ex.Message);
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
