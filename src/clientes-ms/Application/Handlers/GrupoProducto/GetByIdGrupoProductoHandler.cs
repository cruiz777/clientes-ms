using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGrupoProductoByIdHandler : IRequestHandler<GetGrupoProductoByIdQuery, ApiResponse<GrupoProductoResponse>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;

    public GetGrupoProductoByIdHandler(IBaseRepository<GrupoProducto> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<GrupoProductoResponse>> Handle(GetGrupoProductoByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);

            if (e == null)
            {
                return new ApiResponse<GrupoProductoResponse>(
                    Guid.NewGuid(),
                    "OBJECT",
                    null,
                    $"GrupoProducto with ID {request.Id} not found."
                );
            }

            var response = new GrupoProductoResponse(
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

            return new ApiResponse<GrupoProductoResponse>(
                Guid.NewGuid(),
                "OBJECT",
                response,
                "Success"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<GrupoProductoResponse>(
                Guid.NewGuid(),
                "ERROR",
                null,
                ex.Message
            );
        }
    }
}
