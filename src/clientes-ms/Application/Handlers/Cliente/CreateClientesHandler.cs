using clientes_ms.Application.Orchestators;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Cliente;
public class CreateClientesHandler : IRequestHandler<CreateClientesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Clientes> _repository;
    private readonly PersonaOrquestadorService _personaOrquestador;

    public CreateClientesHandler(
        IBaseRepository<Clientes> repository,
        PersonaOrquestadorService personaOrquestador)
    {
        _repository = repository;
        _personaOrquestador = personaOrquestador;
    }

    public async Task<ApiResponse<bool>> Handle(CreateClientesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            long idPersona = request.Request.IdPersona;

            if (idPersona == 0)
            {
                //Pasamos todo el request directamente al orquestador
                idPersona = await _personaOrquestador.CrearPersonaDesdeClienteAsync(request.Request);
            }

            var cliente = new Clientes
            {
                IdPersona = idPersona,
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

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Cliente creado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
