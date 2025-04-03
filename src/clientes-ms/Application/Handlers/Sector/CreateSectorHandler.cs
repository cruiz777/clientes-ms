using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateSectorHandler : IRequestHandler<CreateSectorCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Sector> _repository;
    public CreateSectorHandler(IBaseRepository<Sector> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new Sector { Descripcion = request.Request.Descripcion.Trim() };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}