using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllClientesHandler : IRequestHandler<GetAllClientesQuery, ApiResponse<IEnumerable<ClientesResponse>>>
{
    private readonly IBaseRepository<Clientes> _repository;
    public GetAllClientesHandler(IBaseRepository<Clientes> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ClientesResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClientesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ClientesResponse MapToResponse(Clientes e) => new ClientesResponse
    {
        ClientesCodigo = e.ClientesCodigo,
        NomCli = e.Nomcli?.Trim() ?? string.Empty,
        Dircli = e.Dircli ?? string.Empty,
        Concli = e.Concli ?? string.Empty,
        Email = e.Email ?? string.Empty,
        Telefono = e.Telefono ?? string.Empty,
        Telefono1 = e.Telefono1 ?? string.Empty,
        RazonSocial = e.RazonSocial ?? string.Empty,
        Fax = e.Fax ?? string.Empty,
        Ruc = e.Ruc ?? string.Empty,
        Fecing = e.Fecing ?? DateOnly.MinValue,
        Fecnac = e.Fecnac ?? DateOnly.MinValue,
        Fecfac1 = e.Fecfac1 ?? DateOnly.MinValue,
        Fecfac2 = e.Fecfac2 ?? DateOnly.MinValue,
        Fecfac3 = e.Fecfac3 ?? DateOnly.MinValue,
        Fecfac4 = e.Fecfac4 ?? DateOnly.MinValue,
        Fecfac5 = e.Fecfac5 ?? DateOnly.MinValue,
        Marca1 = e.Marca1 ?? string.Empty,
        Marca2 = e.Marca2 ?? string.Empty,
        Marca3 = e.Marca3 ?? string.Empty,
        Marca4 = e.Marca4 ?? string.Empty,
        Marca5 = e.Marca5 ?? string.Empty,
        Codcue = e.Codcue ?? string.Empty,
        Hello = e.Hello ?? string.Empty,
        Desde = e.Desde ?? 0,
        Fechtre = e.Fechtre ?? DateTime.MinValue,
        Web = e.Web ?? string.Empty,
        Saldo = e.Saldo ?? 0,
        Fecfac = e.Fecfac ?? string.Empty,
        Ciudad = e.Ciudad ?? string.Empty,
        Obs = e.Obs ?? string.Empty,
        Delestado = e.Delestado ?? 0,
        Genero = e.Genero ?? string.Empty,
        Infcamahabitacion = e.Infcamahabitacion ?? string.Empty,
        EmpresaCodigo = e.EmpresaCodigo ?? 0,
        Seguimiento = e.Seguimiento ?? 0,
        Fechaactinact = e.Fechaactinact ?? DateOnly.MinValue,
        IdEstadoEmpresa = e.IdEstadoEmpresa ?? 0,
        Formatodocumento = e.Formatodocumento ?? 0,
        Imprimeobstramite = e.Imprimeobstramite ?? 0,
        IdTipoCliente = e.IdTipoCliente ?? 0,
        IdGrupoProducto = e.IdGrupoProducto ?? 0,
        IdPersona = e.IdPersona ?? 0,
        CodigoPostal = e.CodigoPostal ?? string.Empty,
        CodigoPostal2 = e.CodigoPostal2 ?? string.Empty,
        IdVendedor = e.IdVendedor ?? 0,
        IdCiudad = e.IdCiudad ?? 0,
        IdZona = e.IdZona ?? 0,
        IdGrupoEmpresa = e.IdGrupoEmpresa ?? 0,
        Representante = e.Representante ?? string.Empty,
        ZonaReferencia = e.IdZonaNavigation?.Referencia ?? string.Empty,
        EstadoNombre = e.IdEstadoEmpresaNavigation?.Nombre ?? string.Empty
    };

}