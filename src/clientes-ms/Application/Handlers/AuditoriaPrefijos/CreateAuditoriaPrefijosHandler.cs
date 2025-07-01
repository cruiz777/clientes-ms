using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class CreateAuditoriaPrefijosHandler : IRequestHandler<CreateAuditoriaPrefijosCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<AuditoriaPrefijos> _repository;
    public CreateAuditoriaPrefijosHandler(IBaseRepository<AuditoriaPrefijos> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(CreateAuditoriaPrefijosCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = new AuditoriaPrefijos
            {
                Codpre = request.Request.Codpre?.Trim(),
                Usuario = request.Request.Usuario?.Trim(),
                Fecha = request.Request.Fecha?.Trim(),
                Empresa = request.Request.Empresa?.Trim(),
                Ruc = request.Request.Ruc?.Trim()
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
