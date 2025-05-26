using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetClienteObservacionesByClienteCodigoHandler : IRequestHandler<GetClienteObservacionesByClienteCodigoQuery, ApiResponse<IEnumerable<ClienteObservacionResponse>>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;

    public GetClienteObservacionesByClienteCodigoHandler(IBaseRepository<ClienteObservacion> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<ClienteObservacionResponse>>> Handle(GetClienteObservacionesByClienteCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var lista = await _repository
                .AsQueryable()
                .Where(x => x.ClientesCodigo == request.ClientesCodigo)
                .ToListAsync(cancellationToken);

            var result = lista.Select(e => new ClienteObservacionResponse(
                e.IdClienteObservacion,
                e.Detalle?.Trim() ?? string.Empty,
                e.Fecha ?? DateTime.MinValue,
                e.IdUsuario,
                e.ClientesCodigo,
                e.NombreUsuario,
                e.Linea ?? 0
            )).ToList();

            return new ApiResponse<IEnumerable<ClienteObservacionResponse>>(Guid.NewGuid(), "LIST", result, $"Se encontraron {result.Count} observación(es) para el cliente.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClienteObservacionResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
