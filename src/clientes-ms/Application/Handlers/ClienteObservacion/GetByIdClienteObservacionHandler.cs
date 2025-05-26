using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetClienteObservacionByIdHandler : IRequestHandler<GetClienteObservacionByIdQuery, ApiResponse<ClienteObservacionResponse>>
{
    private readonly IBaseRepository<ClienteObservacion> _repository;
    public GetClienteObservacionByIdHandler(IBaseRepository<ClienteObservacion> repository) => _repository = repository;

    public async Task<ApiResponse<ClienteObservacionResponse>> Handle(GetClienteObservacionByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<ClienteObservacionResponse>(Guid.NewGuid(), "OBJECT", null, $"ClienteObservacion with ID {request.Id} not found.");
            return new ApiResponse<ClienteObservacionResponse>(Guid.NewGuid(), "OBJECT", new ClienteObservacionResponse(e.IdClienteObservacion, e.Detalle?.Trim() ?? string.Empty, e.Fecha ?? DateTime.MinValue, e.IdUsuario , e.ClientesCodigo,e.NombreUsuario,e.Linea??0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ClienteObservacionResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}