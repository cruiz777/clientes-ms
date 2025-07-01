using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteGlnByIdPrefijosHandler : IRequestHandler<DeleteGlnByIdPrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Gln> _repository;

    public DeleteGlnByIdPrefijosHandler(IBaseRepository<Gln> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteGlnByIdPrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var registros = await _repository
                .AsQueryable()
                .Where(g => g.IdPrefijos == request.IdPrefijos)
                .ToListAsync(cancellationToken);

            if (!registros.Any())
            {
                return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", false, "No se encontraron registros con ese IdPrefijos.");
            }

            foreach (var item in registros)
            {
                await _repository.DeleteAsync(item.IdGln);
            }

            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Registros GLN eliminados correctamente por IdPrefijos.");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, $"Error al eliminar: {ex.Message}");
        }
    }
}
