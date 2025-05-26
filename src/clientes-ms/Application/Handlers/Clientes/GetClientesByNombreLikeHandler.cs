using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetClientesByNombreLikeHandler : IRequestHandler<GetClientesByNombreLikeQuery, ApiResponse<IEnumerable<ClientesResponse>>>
{
    private readonly IBaseRepository<Clientes> _repository;

    public GetClientesByNombreLikeHandler(IBaseRepository<Clientes> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<ClientesResponse>>> Handle(GetClientesByNombreLikeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var filtro = request.Nombre?.ToLower() ?? string.Empty;

            var clientes = await _repository
                .AsQueryable()
                .Where(c => c.Nomcli != null && c.Nomcli.ToLower().Contains(filtro))
                .ToListAsync(cancellationToken);

            var resultado = clientes.Select(c => new ClientesResponse
            {
                ClientesCodigo = c.ClientesCodigo,
                NomCli = c.Nomcli ?? string.Empty,
                Ruc = c.Ruc ?? string.Empty
            }).ToList();

            return new ApiResponse<IEnumerable<ClientesResponse>>(
                Guid.NewGuid(),
                "LIST",
                resultado,
                $"Se encontraron {resultado.Count} cliente(s) que coinciden con '{request.Nombre}'.",
                resultado.Count
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClientesResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al buscar clientes: {ex.Message}"
            );
        }
    }
}
