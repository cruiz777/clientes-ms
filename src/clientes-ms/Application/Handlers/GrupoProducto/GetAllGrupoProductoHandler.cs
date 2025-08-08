using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllGrupoProductoHandler : IRequestHandler<GetAllGrupoProductoQuery, ApiResponse<IEnumerable<GrupoProductoResponse>>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;

    public GetAllGrupoProductoHandler(IBaseRepository<GrupoProducto> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<GrupoProductoResponse>>> Handle(GetAllGrupoProductoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync())
                .Select(MapToResponse);

            return new ApiResponse<IEnumerable<GrupoProductoResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                "Retrieved successfully"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<GrupoProductoResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                ex.Message
            );
        }
    }

    private static GrupoProductoResponse MapToResponse(GrupoProducto e) => new(
        idGrupoProducto: e.IdGrupoProducto,
        codigo: e.Codigo?.Trim() ?? string.Empty,
        descripcion: e.Descripcion?.Trim() ?? string.Empty,
        segmento: e.Segmento?.Trim() ?? string.Empty,
        desSegmento: e.DesSegmento?.Trim() ?? string.Empty,
        familia: e.Familia?.Trim() ?? string.Empty,
        desFamilia: e.DesFamilia?.Trim() ?? string.Empty,
        clase: e.Clase?.Trim() ?? string.Empty,
        desClase: e.DesClase?.Trim() ?? string.Empty,
        brick: e.Brick?.Trim() ?? string.Empty,
        desBrick: e.DesBrick?.Trim() ?? string.Empty,
        desSegmentoing: e.DesSegmentoing?.Trim() ?? string.Empty,
        desFamiliaing: e.DesFamiliaing?.Trim() ?? string.Empty,
        desClaseing: e.DesClaseing?.Trim() ?? string.Empty,
        desBricking: e.DesBricking?.Trim() ?? string.Empty,
        brickIncludes: e.BrickIncludes?.Trim() ?? string.Empty,
        brickExcludes: e.BrickExcludes?.Trim() ?? string.Empty,
        estado: e.Estado ?? true
    );
}
