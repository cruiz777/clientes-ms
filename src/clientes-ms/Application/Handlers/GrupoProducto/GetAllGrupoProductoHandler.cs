using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllGrupoProductoHandler : IRequestHandler<GetAllGrupoProductoQuery, ApiResponse<IEnumerable<GrupoProductoResponse>>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    public GetAllGrupoProductoHandler(IBaseRepository<GrupoProducto> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<GrupoProductoResponse>>> Handle(GetAllGrupoProductoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<GrupoProductoResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<GrupoProductoResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static GrupoProductoResponse MapToResponse(GrupoProducto e) => new(e.IdGrupoProducto, e.Codigo?.Trim() ?? string.Empty, e.Descripcion?.Trim() ?? string.Empty, e.Segmento?.Trim() ?? string.Empty, e.DesSegmento?.Trim() ?? string.Empty, e.Familia?.Trim() ?? string.Empty, e.DesFamilia?.Trim() ?? string.Empty, e.Clase?.Trim() ?? string.Empty, e.DesClase?.Trim() ?? string.Empty, e.Brick?.Trim() ?? string.Empty, e.DesBrick?.Trim() ?? string.Empty, e.DesSegmentoing?.Trim() ?? string.Empty, e.DesFamiliaing?.Trim() ?? string.Empty, e.DesClaseing?.Trim() ?? string.Empty, e.DesBricking?.Trim() ?? string.Empty);
}