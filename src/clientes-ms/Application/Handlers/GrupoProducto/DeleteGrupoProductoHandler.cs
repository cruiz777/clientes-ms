using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using clientes_ms.Infrastructure.Persistence.Context;

public class DeleteGrupoProductoHandler : IRequestHandler<DeleteGrupoProductoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<GrupoProducto> _repository;
    private readonly ApplicationDbContext _dbContext;

    public DeleteGrupoProductoHandler(IBaseRepository<GrupoProducto> repository, ApplicationDbContext dbContext)
    {
        _repository = repository;
        _dbContext = dbContext;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteGrupoProductoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var grupo = await _repository.GetByIdAsync(request.IdGrupoProducto);
            if (grupo == null)
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, "GrupoProducto no encontrado.");
            }

            // Validaciones de relaciones
            bool relacionadoConClientes = await _dbContext.Clientes
                .AnyAsync(c => c.IdGrupoProducto == request.IdGrupoProducto, cancellationToken);

            bool relacionadoConCupones = await _dbContext.Cupones
                .AnyAsync(c => c.IdGrupoProducto == request.IdGrupoProducto, cancellationToken);

            bool relacionadoConProductos = await _dbContext.ProductoDatosAdicionales
                .AnyAsync(p => p.IdGrupoProducto == request.IdGrupoProducto, cancellationToken);

            if (relacionadoConClientes || relacionadoConCupones || relacionadoConProductos)
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false,
                    "No se puede eliminar: el grupo está relacionado con clientes, cupones o productos.");
            }

            await _repository.DeleteAsync(request.IdGrupoProducto);

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Eliminado correctamente.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}
