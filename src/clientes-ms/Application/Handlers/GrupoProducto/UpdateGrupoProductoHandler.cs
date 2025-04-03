using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateGrupoProductoHandler : IRequestHandler<UpdateGrupoProductoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    public UpdateGrupoProductoHandler(IBaseRepository<GrupoProducto> repository) => _repository = repository;

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

            // Solo se actualizan campos permitidos (sin modificar la clave primaria)
            existing.Codigo = request.Request.Codigo.Trim();
            existing.Descripcion = request.Request.Descripcion.Trim();
            existing.Segmento = request.Request.Segmento.Trim();
            existing.DesSegmento = request.Request.DesSegmento.Trim();
            existing.Familia = request.Request.Familia.Trim();
            existing.DesFamilia = request.Request.DesFamilia.Trim();
            existing.Clase = request.Request.Clase.Trim();
            existing.DesClase = request.Request.DesClase.Trim();
            existing.Brick = request.Request.Brick.Trim();
            existing.DesBrick = request.Request.DesBrick.Trim();
            existing.DesSegmentoing = request.Request.DesSegmentoing.Trim();
            existing.DesFamiliaing = request.Request.DesFamiliaing.Trim();
            existing.DesClaseing = request.Request.DesClaseing.Trim();
            existing.DesBricking = request.Request.DesBricking.Trim();


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
