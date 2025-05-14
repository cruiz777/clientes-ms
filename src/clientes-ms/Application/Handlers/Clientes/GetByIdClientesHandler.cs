using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetClientesByIdHandler : IRequestHandler<GetClientesByIdQuery, ApiResponse<ClientesResponse>>
{
    private readonly IBaseRepository<Clientes> _repository;
    public GetClientesByIdHandler(IBaseRepository<Clientes> repository) => _repository = repository;

    public async Task<ApiResponse<ClientesResponse>> Handle(GetClientesByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<ClientesResponse>(Guid.NewGuid(), "OBJECT", null, $"Clientes with ID {request.Id} not found.");
            return new ApiResponse<ClientesResponse>(Guid.NewGuid(), "OBJECT", new ClientesResponse(
               e.ClientesCodigo,
e.Nomcli?.Trim() ?? string.Empty,
e.Dircli?.Trim() ?? string.Empty,
e.Concli?.Trim() ?? string.Empty,
e.Email?.Trim() ?? string.Empty,
e.Telefono?.Trim() ?? string.Empty,
e.Telefono1?.Trim() ?? string.Empty,
e.RazonSocial?.Trim() ?? string.Empty,
e.Fax?.Trim() ?? string.Empty,
e.Ruc?.Trim() ?? string.Empty,
e.Fecing ?? DateOnly.MinValue,
e.Fecnac ?? DateOnly.MinValue,
e.Fecfac1 ?? DateOnly.MinValue,
e.Fecfac2 ?? DateOnly.MinValue,
e.Fecfac3 ?? DateOnly.MinValue,
e.Fecfac4 ?? DateOnly.MinValue,
e.Fecfac5 ?? DateOnly.MinValue,
e.Marca1?.Trim() ?? string.Empty,
e.Marca2?.Trim() ?? string.Empty,
e.Marca3?.Trim() ?? string.Empty,
e.Marca4?.Trim() ?? string.Empty,
e.Marca5?.Trim() ?? string.Empty,
e.Codcue?.Trim() ?? string.Empty,
e.Hello?.Trim() ?? string.Empty,
e.Desde ?? 0,
e.Fechtre ?? DateTime.MinValue,
e.Web?.Trim() ?? string.Empty,
e.Saldo ?? 0,
e.Fecfac?.Trim() ?? string.Empty,
e.Ciudad?.Trim() ?? string.Empty,
e.Obs?.Trim() ?? string.Empty,
e.Delestado ?? 0,
e.Genero?.Trim() ?? string.Empty,
e.Infcamahabitacion?.Trim() ?? string.Empty,
e.EmpresaCodigo ?? 0,
e.Seguimiento ?? 0,
e.Fechaactinact ?? DateOnly.MinValue,
e.IdEstadoEmpresa ?? 0,
e.Formatodocumento ?? 0,
e.Imprimeobstramite ?? 0,
e.IdTipoCliente ?? 0,
e.IdGrupoProducto ?? 0,
e.IdPersona ?? 0,
e.CodigoPostal?.Trim() ?? string.Empty,
e.CodigoPostal2?.Trim() ?? string.Empty,
e.IdVendedor ?? 0,
e.IdCiudad ?? 0,
e.IdZona ?? 0,
e.IdGrupoEmpresa ?? 0,
e.Representante?.Trim() ?? string.Empty,
e.IdZonaNavigation?.Referencia ?? string.Empty,
e.IdEstadoEmpresaNavigation?.Nombre ?? string.Empty,
e.Fecmod??DateOnly.MinValue,
e.Usumod?? string.Empty

                ), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ClientesResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}