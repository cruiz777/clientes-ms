using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGrupoProductoByIdHandler : IRequestHandler<GetGrupoProductoByIdQuery, ApiResponse<GrupoProductoResponse>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    public GetGrupoProductoByIdHandler(IBaseRepository<GrupoProducto> repository) => _repository = repository;

    public async Task<ApiResponse<GrupoProductoResponse>> Handle(GetGrupoProductoByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "OBJECT", null, $"GrupoProducto with ID {request.Id} not found.");
            return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "OBJECT", new GrupoProductoResponse(e.IdGrupoProducto, e.Codigo?.Trim() ?? string.Empty,e.Descripcion?.Trim() ?? string.Empty,e.Segmento?.Trim()?? string.Empty,e.DesSegmento?.Trim()?? string.Empty,e.Familia?.Trim()?? string.Empty,e.DesFamilia?.Trim() ?? string.Empty,e.Clase?.Trim() ?? string.Empty,e.DesClase?.Trim() ?? string.Empty,e.Brick?.Trim() ?? string.Empty,e.DesBrick?.Trim() ?? string.Empty,e.DesSegmentoing?.Trim() ?? string.Empty,e.DesFamiliaing?.Trim() ?? string.Empty,e.DesClaseing?.Trim() ?? string.Empty,e.DesBricking?.Trim() ?? string.Empty), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<GrupoProductoResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}