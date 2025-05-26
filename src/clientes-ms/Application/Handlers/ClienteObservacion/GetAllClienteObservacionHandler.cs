using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllClienteObservacionHandler : IRequestHandler<GetAllClienteObservacionQuery, ApiResponse<IEnumerable<ClienteObservacionResponse>>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;
    public GetAllClienteObservacionHandler(IBaseRepository<ClienteObservacion> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ClienteObservacionResponse>>> Handle(GetAllClienteObservacionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ClienteObservacionResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClienteObservacionResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ClienteObservacionResponse MapToResponse(ClienteObservacion e) => new(e.IdClienteObservacion, e.Detalle?.Trim() ?? string.Empty, e.Fecha ?? DateTime.MinValue, e.IdUsuario , e.ClientesCodigo,e.NombreUsuario,e.Linea??0 );
}