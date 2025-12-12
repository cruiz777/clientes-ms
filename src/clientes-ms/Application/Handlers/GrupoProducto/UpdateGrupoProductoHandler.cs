using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateGrupoProductoHandler : IRequestHandler<UpdateGrupoProductoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;

    public UpdateGrupoProductoHandler(IBaseRepository<GrupoProducto> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateGrupoProductoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdGrupoProducto);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"GrupoProducto with ID {request.IdGrupoProducto} not found."
                );
            }

            // ✅ Actualizar solo si el valor no está vacío o nulo
            if (!string.IsNullOrWhiteSpace(request.Request.Codigo))
                existing.Codigo = request.Request.Codigo.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.Descripcion))
                existing.Descripcion = request.Request.Descripcion.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.Segmento))
                existing.Segmento = request.Request.Segmento.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesSegmento))
                existing.DesSegmento = request.Request.DesSegmento.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.Familia))
                existing.Familia = request.Request.Familia.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesFamilia))
                existing.DesFamilia = request.Request.DesFamilia.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.Clase))
                existing.Clase = request.Request.Clase.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesClase))
                existing.DesClase = request.Request.DesClase.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.Brick))
                existing.Brick = request.Request.Brick.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesBrick))
                existing.DesBrick = request.Request.DesBrick.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesSegmentoing))
                existing.DesSegmentoing = request.Request.DesSegmentoing.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesFamiliaing))
                existing.DesFamiliaing = request.Request.DesFamiliaing.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesClaseing))
                existing.DesClaseing = request.Request.DesClaseing.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.DesBricking))
                existing.DesBricking = request.Request.DesBricking.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.BrickIncludes))
                existing.BrickIncludes = request.Request.BrickIncludes.Trim();

            if (!string.IsNullOrWhiteSpace(request.Request.BrickExcludes))
                existing.BrickExcludes = request.Request.BrickExcludes.Trim();

            // Estado siempre se debe actualizar (booleano)
            existing.Estado = request.Request.Estado;

            await _repository.UpdateAsync(request.IdGrupoProducto, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Updated successfully"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "ERROR",
                false,
                ex.Message
            );
        }
    }
}
