using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

public class DeleteAuditoriaPrefijosHandler : IRequestHandler<DeleteAuditoriaPrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaPrefijos> _repository;

    public DeleteAuditoriaPrefijosHandler(IBaseRepository<AuditoriaPrefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(DeleteAuditoriaPrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Buscar entidad por ID usando AsQueryable y FirstOrDefaultAsync
            var entity = await _repository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.IdAuditoriaPrefijos, cancellationToken);

            if (entity == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "BOOLEAN",
                    false,
                    $"Auditoría con ID {request.IdAuditoriaPrefijos} no encontrada."
                );
            }

            // Eliminar la entidad
            await _repository.DeleteAsync(entity.Id);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Auditoría eliminada correctamente."
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
