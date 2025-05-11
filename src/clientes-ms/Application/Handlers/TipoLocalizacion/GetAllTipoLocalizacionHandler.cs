using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllTipoLocalizacionHandler : IRequestHandler<GetAllTipoLocalizacionQuery, ApiResponse<IEnumerable<TipoLocalizacionResponse>>>
{
    private readonly IBaseRepository<TipoLocalizacion> _repository;
    public GetAllTipoLocalizacionHandler(IBaseRepository<TipoLocalizacion> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<TipoLocalizacionResponse>>> Handle(GetAllTipoLocalizacionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<TipoLocalizacionResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<TipoLocalizacionResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static TipoLocalizacionResponse MapToResponse(TipoLocalizacion e) => new(e.IdTipoLocalizacion, e.Descripcion?.Trim() ?? string.Empty,e.Estado??false);
}