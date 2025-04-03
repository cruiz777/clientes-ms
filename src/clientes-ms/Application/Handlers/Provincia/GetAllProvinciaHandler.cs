using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllProvinciaHandler : IRequestHandler<GetAllProvinciaQuery, ApiResponse<IEnumerable<ProvinciaResponse>>>
{
    private readonly IBaseRepository<Provincia> _repository;
    public GetAllProvinciaHandler(IBaseRepository<Provincia> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<ProvinciaResponse>>> Handle(GetAllProvinciaQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<ProvinciaResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ProvinciaResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static ProvinciaResponse MapToResponse(Provincia e) => new(e.IdProvincia, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdPais);
}