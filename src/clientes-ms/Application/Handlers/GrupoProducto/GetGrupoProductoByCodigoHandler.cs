using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGrupoProductoByCodigoHandler : IRequestHandler<GetGrupoProductoByCodigoQuery, ApiResponse<GrupoProductoResponse>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;

    public GetGrupoProductoByCodigoHandler(IBaseRepository<GrupoProducto> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<GrupoProductoResponse>> Handle(GetGrupoProductoByCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.FirstOrDefaultAsync(g => g.Codigo != null && g.Codigo.Trim() == request.Codigo.Trim());

            if (entity == null)
                return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "OBJECT", null, $"GrupoProducto with code '{request.Codigo}' not found.");

            var response = new GrupoProductoResponse(
    entity.IdGrupoProducto,
    entity.Codigo?.Trim() ?? string.Empty,
    entity.Descripcion?.Trim() ?? string.Empty,
    entity.Segmento?.Trim() ?? string.Empty,
    entity.DesSegmento?.Trim() ?? string.Empty,
    entity.Familia?.Trim() ?? string.Empty,
    entity.DesFamilia?.Trim() ?? string.Empty,
    entity.Clase?.Trim() ?? string.Empty,
    entity.DesClase?.Trim() ?? string.Empty,
    entity.Brick?.Trim() ?? string.Empty,
    entity.DesBrick?.Trim() ?? string.Empty,
    entity.DesSegmentoing?.Trim() ?? string.Empty,
    entity.DesFamiliaing?.Trim() ?? string.Empty,
    entity.DesClaseing?.Trim() ?? string.Empty,
    entity.DesBricking?.Trim() ?? string.Empty,
    entity.BrickIncludes?.Trim() ?? string.Empty,
    entity.BrickExcludes?.Trim() ?? string.Empty,
    entity.Estado ?? true
);


            return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "OBJECT", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
