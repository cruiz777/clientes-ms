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

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Nomcli = request.Request.Nomcli.Trim();
            existing.Dircli = request.Request.Dircli.Trim();
            existing.Concli = request.Request.Concli.Trim();
            existing.Email = request.Request.Email.Trim();
            existing.Telefono = request.Request.Telefono.Trim();
            existing.Telefono1 = request.Request.Telefono1.Trim();
            existing.RazonSocial = request.Request.RazonSocial.Trim();
            existing.Fax = request.Request.Fax.Trim();
            existing.Ruc = request.Request.Ruc.Trim();
            existing.Fecing = request.Request.Fecing;
            existing.Fecnac = request.Request.Fecnac;
            existing.Fecfac1 = request.Request.Fecfac1;
            existing.Fecfac2 = request.Request.Fecfac2;
            existing.Fecfac3 = request.Request.Fecfac3;
            existing.Fecfac4 = request.Request.Fecfac4;
            existing.Fecfac5 = request.Request.Fecfac5;
            existing.Marca1 = request.Request.Marca1.Trim();
            existing.Marca2 = request.Request.Marca2.Trim();
            existing.Marca3 = request.Request.Marca3.Trim();
            existing.Marca4 = request.Request.Marca4.Trim();
            existing.Marca5 = request.Request.Marca5.Trim();
            existing.Codcue = request.Request.Codcue.Trim();
            existing.Hello = request.Request.Hello.Trim();
            existing.Desde = request.Request.Desde;
            existing.Fechtre = request.Request.Fechtre;
            existing.Web = request.Request.Web.Trim();
            existing.Saldo = request.Request.Saldo;
            existing.Fecfac = request.Request.Fecfac.Trim();
            existing.Ciudad = request.Request.Ciudad.Trim();
            existing.Obs = request.Request.Obs.Trim();
            existing.Delestado = request.Request.Delestado;
            existing.Genero = request.Request.Genero.Trim();
            existing.Infcamahabitacion = request.Request.Infcamahabitacion.Trim();
            existing.EmpresaCodigo = request.Request.EmpresaCodigo;
            existing.Seguimiento = request.Request.Seguimiento;
            existing.Fechaactinact = request.Request.Fechaactinact;
            existing.IdEstadoEmpresa = request.Request.IdEstadoEmpresa;
            existing.Formatodocumento = request.Request.Formatodocumento;
            existing.Imprimeobstramite = request.Request.Imprimeobstramite;
            existing.IdTipoCliente = request.Request.IdTipoCliente;
            existing.IdGrupoProducto = request.Request.IdGrupoProducto;
            existing.IdPersona = request.Request.IdPersona;
            existing.CodigoPostal = request.Request.CodigoPostal.Trim();
            existing.CodigoPostal2 = request.Request.CodigoPostal2.Trim();
            existing.IdVendedor = request.Request.IdVendedor;
            existing.IdCiudad = request.Request.IdCiudad;
            existing.IdZona = request.Request.IdZona;
            existing.IdGrupoEmpresa = request.Request.IdGrupoEmpresa;
            existing.Representante = request.Request.Representante.Trim();



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
