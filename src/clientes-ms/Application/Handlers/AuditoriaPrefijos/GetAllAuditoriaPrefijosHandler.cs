using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllAuditoriaPrefijosHandler : IRequestHandler<GetAllAuditoriaPrefijosQuery, ApiResponse<IEnumerable<AuditoriaPrefijosResponse>>>
{
    private readonly IBaseRepository<AuditoriaPrefijos> _repository;

    public GetAllAuditoriaPrefijosHandler(IBaseRepository<AuditoriaPrefijos> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<AuditoriaPrefijosResponse>>> Handle(GetAllAuditoriaPrefijosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<AuditoriaPrefijosResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<AuditoriaPrefijosResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static AuditoriaPrefijosResponse MapToResponse(AuditoriaPrefijos e) =>
        new AuditoriaPrefijosResponse(
            e.Id,
            e.Codpre,
            e.Usuario,
            e.Fecha,
            e.Empresa,
            e.Ruc
        );
}
