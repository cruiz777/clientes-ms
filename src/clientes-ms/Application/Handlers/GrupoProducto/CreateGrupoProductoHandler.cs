using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateGrupoProductoHandler : IRequestHandler<CreateGrupoProductoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    public CreateGrupoProductoHandler(IBaseRepository<GrupoProducto> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateGrupoProductoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new GrupoProducto {
                Codigo = request.Request.Codigo.Trim(),
                Descripcion = request.Request.Descripcion.Trim(),
                Segmento = request.Request.Segmento.Trim(),
                DesSegmento = request.Request.DesSegmento.Trim(),
                Familia = request.Request.Familia.Trim(),
                DesFamilia = request.Request.DesFamilia.Trim(),
                Clase = request.Request.Clase.Trim(),
                DesClase = request.Request.DesClase.Trim(),
                Brick = request.Request.Brick.Trim(),
                DesBrick = request.Request.DesBrick.Trim(),
                DesSegmentoing = request.Request.DesSegmentoing.Trim(),
                DesFamiliaing = request.Request.DesFamiliaing.Trim(),
                DesClaseing = request.Request.DesClaseing.Trim(),
                DesBricking = request.Request.DesBricking.Trim()
            };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}