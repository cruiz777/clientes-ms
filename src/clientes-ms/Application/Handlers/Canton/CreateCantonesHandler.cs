using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateCantonesHandler : IRequestHandler<CreateCantonesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Cantones> _repository;
    public CreateCantonesHandler(IBaseRepository<Cantones> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateCantonesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Cantones { Referencia = request.Request.Referencia.Trim(), Nombre = request.Request.Nombre.Trim(),IdProvincia=request.Request.IdProvincia };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}