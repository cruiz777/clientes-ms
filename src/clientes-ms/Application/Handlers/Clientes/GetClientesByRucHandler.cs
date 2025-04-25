using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class GetClientesByRucHandler : IRequestHandler<GetClientesByRucQuery, ApiResponse<IEnumerable<ClientesResponse>>>
{
    private readonly IBaseRepository<Clientes> _repository;
    public GetClientesByRucHandler(IBaseRepository<Clientes> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetClientesByRucQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var clientes = await _repository
                .AsQueryable()
                .Where(e => e.Ruc != null && e.Ruc.ToLower().Contains(request.Ruc.ToLower()))
                .ToListAsync(cancellationToken);

            var result = clientes.Select(entity => new ClientesResponse
            {
                ClientesCodigo = entity.ClientesCodigo,
                NomCli = entity.Nomcli?.Trim() ?? string.Empty,
                Ruc = entity.Ruc ?? string.Empty
            }).ToList();

            return new ApiResponse<IEnumerable<ClientesResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} cliente(s) con coincidencia de RUC.",
                result.Count);
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClientesResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al buscar clientes por RUC: {ex.Message}");
        }
    }
}
