using clientes_ms.Application.Records.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;

public class GetResumenClientesHandler : IRequestHandler<GetClientesByResumen, ApiResponse<IEnumerable<ClientesResponse>>>
{
    private readonly IBaseRepository<Clientes> _repository;

    public GetResumenClientesHandler(IBaseRepository<Clientes> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetClientesByResumen request, CancellationToken cancellationToken)
    {
        try
        {
            var clientes = await _repository
            .AsQueryable()
            .Include(e => e.IdZonaNavigation)
            .Include(e => e.IdEstadoEmpresaNavigation)
            .ToListAsync(cancellationToken);

            var result = clientes.Select(e => new ClientesResponse
            {
                ClientesCodigo = e.ClientesCodigo,
                NomCli = e.Nomcli ?? string.Empty,
                Ruc = e.Ruc ?? string.Empty,
                Dircli = e.Dircli ?? string.Empty,
                Fecing = e.Fecing,
                ZonaReferencia = e.IdZonaNavigation?.Referencia ?? string.Empty,
                EstadoNombre = e.IdEstadoEmpresaNavigation?.Nombre ?? string.Empty
            }).ToList();

            return new ApiResponse<IEnumerable<ClientesResponse>>(
            Guid.NewGuid(),
            "LIST",
            result,
            $"Se encontraron {result.Count} Cliente(s).",
            result.Count()
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClientesResponse>>(
            Guid.NewGuid(),
            "ERROR",
            null,
            $"Error al obtener los clientes: {ex.Message}"
            );
        }
    }
}
