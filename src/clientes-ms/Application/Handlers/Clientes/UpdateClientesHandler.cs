using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateClientesHandler : IRequestHandler<UpdateClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Clientes> _repository;
    public UpdateClientesHandler(IBaseRepository<Clientes> repository) => _repository = repository;

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

            // Condicionales solo si el valor viene definido
            // Asignaciones condicionales para actualización parcial del cliente

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

            //if (!string.IsNullOrWhiteSpace(request.Request.Ruc))
            //    existing.Ruc = request.Request.Ruc.Trim();

            //if (request.Request.Fecing.HasValue)
            //    existing.Fecing = request.Request.Fecing.Value;

            //if (request.Request.Fecnac.HasValue)
            //    existing.Fecnac = request.Request.Fecnac.Value;

            //if (request.Request.Fecfac1.HasValue)
            //    existing.Fecfac1 = request.Request.Fecfac1.Value;

            //if (request.Request.Fecfac2.HasValue)
            //    existing.Fecfac2 = request.Request.Fecfac2.Value;

            //if (request.Request.Fecfac3.HasValue)
            //    existing.Fecfac3 = request.Request.Fecfac3.Value;

            //if (request.Request.Fecfac4.HasValue)
            //    existing.Fecfac4 = request.Request.Fecfac4.Value;

            //if (request.Request.Fecfac5.HasValue)
            //    existing.Fecfac5 = request.Request.Fecfac5.Value;

            //if (!string.IsNullOrWhiteSpace(request.Request.Marca1))
            //    existing.Marca1 = request.Request.Marca1.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Marca2))
            //    existing.Marca2 = request.Request.Marca2.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Marca3))
            //    existing.Marca3 = request.Request.Marca3.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Marca4))
            //    existing.Marca4 = request.Request.Marca4.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Marca5))
            //    existing.Marca5 = request.Request.Marca5.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Codcue))
            //    existing.Codcue = request.Request.Codcue.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Hello))
            //    existing.Hello = request.Request.Hello.Trim();

            //if (request.Request.Desde.HasValue)
            //    existing.Desde = request.Request.Desde.Value;

            //if (request.Request.Fechtre.HasValue)
            //    existing.Fechtre = request.Request.Fechtre.Value;

            if (!string.IsNullOrWhiteSpace(request.Request.Web))
                existing.Web = request.Request.Web.Trim();

            //if (request.Request.Saldo.HasValue)
            //    existing.Saldo = request.Request.Saldo.Value;

            //if (!string.IsNullOrWhiteSpace(request.Request.Fecfac))
            //    existing.Fecfac = request.Request.Fecfac.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Ciudad))
            //    existing.Ciudad = request.Request.Ciudad.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Obs))
            //    existing.Obs = request.Request.Obs.Trim();

            //if (request.Request.Delestado.HasValue)
            //    existing.Delestado = request.Request.Delestado.Value;

            //if (!string.IsNullOrWhiteSpace(request.Request.Genero))
            //    existing.Genero = request.Request.Genero.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.Infcamahabitacion))
            //    existing.Infcamahabitacion = request.Request.Infcamahabitacion.Trim();

            //if (request.Request.EmpresaCodigo.HasValue)
            //    existing.EmpresaCodigo = request.Request.EmpresaCodigo.Value;

            //if (request.Request.Seguimiento.HasValue)
            //    existing.Seguimiento = request.Request.Seguimiento.Value;

            //if (request.Request.Fechaactinact.HasValue)
            //    existing.Fechaactinact = request.Request.Fechaactinact.Value;

            if (request.Request.IdEstadoEmpresa.HasValue)
                existing.IdEstadoEmpresa = request.Request.IdEstadoEmpresa.Value;

            //if (request.Request.Formatodocumento.HasValue)
            //    existing.Formatodocumento = request.Request.Formatodocumento.Value;

            //if (request.Request.Imprimeobstramite.HasValue)
            //    existing.Imprimeobstramite = request.Request.Imprimeobstramite.Value;

            if (request.Request.IdTipoCliente.HasValue)
                existing.IdTipoCliente = request.Request.IdTipoCliente.Value;

            if (request.Request.IdGrupoProducto.HasValue)
                existing.IdGrupoProducto = request.Request.IdGrupoProducto.Value;

            //if (request.Request.IdPersona.HasValue)
            //    existing.IdPersona = request.Request.IdPersona.Value;

            if (!string.IsNullOrWhiteSpace(request.Request.CodigoPostal))
                existing.CodigoPostal = request.Request.CodigoPostal.Trim();

            //if (!string.IsNullOrWhiteSpace(request.Request.CodigoPostal2))
            //    existing.CodigoPostal2 = request.Request.CodigoPostal2.Trim();

            //if (request.Request.IdVendedor.HasValue)
            //    existing.IdVendedor = request.Request.IdVendedor.Value;

            if (request.Request.IdCiudad.HasValue)
                existing.IdCiudad = request.Request.IdCiudad.Value;

            if (request.Request.IdZona.HasValue)
                existing.IdZona = request.Request.IdZona.Value;

            if (request.Request.IdGrupoEmpresa.HasValue)
                existing.IdGrupoEmpresa = request.Request.IdGrupoEmpresa.Value;

            if (!string.IsNullOrWhiteSpace(request.Request.Representante))
                existing.Representante = request.Request.Representante.Trim();

            if (request.Request.Fecmod.HasValue)
            {
                existing.Fecmod = request.Request.Fecmod;
            }

            if (!string.IsNullOrWhiteSpace(request.Request.Usumod))
                existing.Usumod = request.Request.Usumod.Trim();

            await _repository.UpdateAsync(request.IdClientes, existing);

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
