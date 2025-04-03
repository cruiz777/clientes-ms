using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateNumeroControlHandler : IRequestHandler<CreateNumeroControlCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<NumeroControl> _repository;
    public CreateNumeroControlHandler(IBaseRepository<NumeroControl> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateNumeroControlCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new NumeroControl { Codcon = request.Request.Codcon, Modcon  = request.Request.Modcon?.Trim() ?? string.Empty, Tipcon = request.Request.Tipcon.Trim(), Numcon = request.Request.Numcon.Trim(),Ocupado=request.Request.Ocupado, EmpresaCodigo=request.Request.EmpresaCodigo };
            await _repository.AddAsync(entity);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Created successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}