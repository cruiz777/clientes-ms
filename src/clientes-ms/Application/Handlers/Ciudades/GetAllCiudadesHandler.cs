using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllCiudadesHandler : IRequestHandler<GetAllCiudadesQuery, ApiResponse<IEnumerable<CiudadesResponse>>>
{
    private readonly IBaseRepository<Ciudades> _repository;
    public GetAllCiudadesHandler(IBaseRepository<Ciudades> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<CiudadesResponse>>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<CiudadesResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<CiudadesResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static CiudadesResponse MapToResponse(Ciudades e) => new(e.IdCiudad, e.Referencia?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty,e.IdCiudad);
}