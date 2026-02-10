using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Infrastructure.Persistence.Context; // <-- AJUSTA si tu DbContext está en otro namespace

namespace clientes_ms.Application.Handlers.Cliente
{
    public class UpdateClientesHandler : IRequestHandler<UpdateClientesCommand, ApiResponse<bool>>
    {
        private readonly IBaseRepository<Clientes> _repository;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<UpdateClientesHandler> _logger;

        public UpdateClientesHandler(
            IBaseRepository<Clientes> repository,
            ApplicationDbContext db,
            ILogger<UpdateClientesHandler> logger)
        {
            _repository = repository;
            _db = db;
            _logger = logger;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateClientesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(request.IdClientes);
                if (existing == null)
                {
                    return new ApiResponse<bool>(
                        Guid.NewGuid(),
                        "OBJECT",
                        false,
                        $"Clientes with ID {request.IdClientes} not found."
                    );
                }

                // ==========================================
                // 1) Capturar estado ANTERIOR (long? -> long?)
                // ==========================================
                long? estadoAnterior = existing.IdEstadoEmpresa;

                // ==========================================
                // 2) Update parcial (tu lógica)
                // ==========================================
                if (!string.IsNullOrWhiteSpace(request.Request.Nomcli))
                    existing.Nomcli = request.Request.Nomcli.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Dircli))
                    existing.Dircli = request.Request.Dircli.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Concli))
                    existing.Concli = request.Request.Concli.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Email))
                    existing.Email = request.Request.Email.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Telefono))
                    existing.Telefono = request.Request.Telefono.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Telefono1))
                    existing.Telefono1 = request.Request.Telefono1.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.RazonSocial))
                    existing.RazonSocial = request.Request.RazonSocial.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Fax))
                    existing.Fax = request.Request.Fax.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Web))
                    existing.Web = request.Request.Web.Trim();

                if (request.Request.IdTipoCliente.HasValue)
                    existing.IdTipoCliente = request.Request.IdTipoCliente.Value;

                if (request.Request.IdGrupoProducto.HasValue)
                    existing.IdGrupoProducto = request.Request.IdGrupoProducto.Value;

                if (!string.IsNullOrWhiteSpace(request.Request.CodigoPostal))
                    existing.CodigoPostal = request.Request.CodigoPostal.Trim();

                if (!string.IsNullOrWhiteSpace(request.Request.Hello))
                    existing.Hello = request.Request.Hello.Trim();

                existing.FechaCeseAct = request.Request.FechaCeseActParsed;

                existing.MotivoCeseAct = string.IsNullOrWhiteSpace(request.Request.MotivoCeseAct)
                    ? null
                    : request.Request.MotivoCeseAct.Trim();

                existing.IdCiudad = request.Request.IdCiudad;

                if (request.Request.Fecnac.HasValue)
                    existing.Fecnac = request.Request.Fecnac.Value;

                if (request.Request.IdZona.HasValue)
                    existing.IdZona = request.Request.IdZona.Value;

                if (request.Request.IdGrupoEmpresa.HasValue)
                    existing.IdGrupoEmpresa = request.Request.IdGrupoEmpresa.Value;

                existing.Representante = string.IsNullOrWhiteSpace(request.Request.Representante)
                    ? request.Request.RazonSocial?.Trim() ?? existing.Representante
                    : request.Request.Representante.Trim();

                if (request.Request.Fecmod.HasValue)
                    existing.Fecmod = request.Request.Fecmod;

                if (!string.IsNullOrWhiteSpace(request.Request.Usumod))
                    existing.Usumod = request.Request.Usumod.Trim();

                // ==========================================
                // 3) Capturar estado NUEVO SOLO si viene en request
                // ==========================================
                long? estadoNuevo = null;

                if (request.Request.IdEstadoEmpresa.HasValue)
                {
                    estadoNuevo = request.Request.IdEstadoEmpresa.Value; // ✅ long
                    existing.IdEstadoEmpresa = estadoNuevo.Value;
                }

                // ==========================================
                // 4) Guardar cliente
                // ==========================================
                await _repository.UpdateAsync(request.IdClientes, existing);

                // ==========================================
                // 5) Ejecutar SP SOLO si cambia 1<->2
                // ==========================================
                if (estadoNuevo.HasValue && estadoAnterior.HasValue)
                {
                    bool cambio12 = (estadoAnterior.Value == 1L && estadoNuevo.Value == 2L);
                    bool cambio21 = (estadoAnterior.Value == 2L && estadoNuevo.Value == 1L);

                    if (cambio12 || cambio21)
                    {
                        bool activoBit = (estadoNuevo.Value == 1L); // 1 => true, 2 => false

                        // 👇 CAMBIA este campo si tu entidad lo tiene con otro nombre:
                        var clientesCodigo = existing.ClientesCodigo; // debe ser el clientes_codigo usado en SIC

                        await _db.Database.ExecuteSqlInterpolatedAsync(
                            $@"EXEC sic.sp_SetActivoClienteProductos
                               @clientes_codigo = {clientesCodigo},
                               @activo = {activoBit}",
                            cancellationToken
                        );

                        _logger.LogInformation(
                            "SP ejecutado: clientes_codigo={clientesCodigo}, activo={activo}",
                            clientesCodigo, activoBit
                        );
                    }
                }

                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "BOOLEAN",
                    true,
                    "Updated successfully"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Clientes ID {IdClientes}", request.IdClientes);

                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "ERROR",
                    false,
                    ex.Message
                );
            }
        }
    }
}
