using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Application.Queries.GrupoProducto;

public class SearchGrupoProductoHandler : IRequestHandler<SearchGrupoProductoQuery, ApiResponse<IEnumerable<GrupoProductoResponse>>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;

    public SearchGrupoProductoHandler(IBaseRepository<GrupoProducto> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<GrupoProductoResponse>>> Handle(
        SearchGrupoProductoQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            IQueryable<GrupoProducto> query = _repository.AsQueryableNoTracking();

            // ✅ Aplicar filtro si hay término de búsqueda
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchLower = request.SearchTerm.ToLower();

                query = query.Where(g =>
                    EF.Functions.Like(g.Codigo!.ToLower(), $"%{searchLower}%") ||
                    EF.Functions.Like(g.Brick!.ToLower(), $"%{searchLower}%") ||
                    EF.Functions.Like(g.DesBrick!.ToLower(), $"%{searchLower}%")
                );
            }

            // ✅ Ordenar y limitar
            var result = await query
                .OrderBy(g => g.Codigo)
                .Take(request.Limit)
                .Select(e => MapToResponse(e))
                .ToListAsync(cancellationToken);

            return new ApiResponse<IEnumerable<GrupoProductoResponse>>(
                Guid.NewGuid(),
                "SEARCH",
                result,
                $"Retrieved {result.Count} results successfully"
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