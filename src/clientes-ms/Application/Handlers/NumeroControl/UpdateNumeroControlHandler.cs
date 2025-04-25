using clientes_ms.Application.Commands.NumeroControl;
using clientes_ms.Application.DTOs.NumeroControl;
using clientes_ms.Application.Records.Response;
using EntNumeroControl = clientes_ms.Domain.Entities.NumeroControl; // Alias para evitar colisión
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.NumeroControl
{
    public class UpdateNumeroControlHandler : IRequestHandler<UpdateNumeroControlCommand, ApiResponse<bool>>
    {
        private readonly IBaseRepository<EntNumeroControl> _repository;

        public UpdateNumeroControlHandler(IBaseRepository<EntNumeroControl> repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateNumeroControlCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"NumeroControl with ID {request.Id} not found.");
            }

            existing.Numcon = request.Request.Numcon.Trim();
            existing.Ocupado = request.Request.Ocupado;

            await _repository.UpdateAsync(request.Id, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Updated successfully");
        }
    }
}
