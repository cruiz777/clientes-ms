using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UpdateOrdenPrefijoCommand : IRequest<ApiResponse<bool>>
{
    public int IdPrefijos { get; set; }
    public int Orden { get; set; }
}

public class UpdateOrdenPrefijoHandler : IRequestHandler<UpdateOrdenPrefijoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Prefijos> _repository;

    public UpdateOrdenPrefijoHandler(IBaseRepository<Prefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateOrdenPrefijoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository.GetByIdAsync(request.IdPrefijos);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"No se encontró el prefijo con ID {request.IdPrefijos}"
                );
            }

            // ✅ Actualizar solo el campo Orden
            existing.Orden = request.Orden;

            await _repository.UpdateAsync(existing.IdPrefijos, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Orden actualizado correctamente."
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
