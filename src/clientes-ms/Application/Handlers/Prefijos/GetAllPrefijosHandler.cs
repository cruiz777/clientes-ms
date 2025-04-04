using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllPrefijosHandler : IRequestHandler<GetAllPrefijosQuery, ApiResponse<IEnumerable<PrefijosResponse>>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public GetAllPrefijosHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<PrefijosResponse>>> Handle(GetAllPrefijosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<PrefijosResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<PrefijosResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static PrefijosResponse MapToResponse(Prefijos e) => new(e.IdPrefijos, e.Codpre?.Trim() ?? string.Empty, e.Fecha ?? DateOnly.MinValue, e.FechaCierre ?? DateTime.MinValue, e.Observacion?.Trim() ?? string.Empty, e.Digitos?.Trim() ?? string.Empty, e.Estado ?? false, e.Control??0, e.Ngln??0, e.Bandera??0, e.Facturar?.Trim() ?? string.Empty, e.Codpro?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty, e.Fecfac?.Trim() ?? string.Empty, e.ReferenciaInterna?.Trim() ?? string.Empty, e.Prefijosgs1?.Trim() ?? string.Empty, e.OrigenPrefijo?.Trim() ?? string.Empty,e.Orden??0,e.ClientesCodigo ?? 0);
}