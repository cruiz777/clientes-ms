using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllZonaHandler : IRequestHandler<GetAllZonaQuery, ApiResponse<IEnumerable<ZonaResponse>>>
{
    private readonly IBaseRepository<Zona> _repository;
    public GetAllZonaHandler(IBaseRepository<Zona> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ZonaResponse>>> Handle(GetAllZonaQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ZonaResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ZonaResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ZonaResponse MapToResponse(Zona e) => new(e.IdZona, e.Referencia?.Trim() ?? string.Empty,e.Nombre?.Trim() ?? string.Empty,e.Numero?.Trim()?? string.Empty,e.EmpresaCodigo??0);
}