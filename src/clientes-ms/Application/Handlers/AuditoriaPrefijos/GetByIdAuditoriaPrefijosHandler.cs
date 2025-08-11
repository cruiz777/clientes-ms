using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAuditoriaPrefijosByIdHandler : IRequestHandler<GetAuditoriaPrefijosByIdQuery, ApiResponse<AuditoriaPrefijosResponse>>
{
    private readonly IBaseRepository<AuditoriaPrefijos> _repository;

    public GetAuditoriaPrefijosByIdHandler(IBaseRepository<AuditoriaPrefijos> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<AuditoriaPrefijosResponse>> Handle(GetAuditoriaPrefijosByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
            {
                return new ApiResponse<AuditoriaPrefijosResponse>(Guid.NewGuid(), "OBJECT", null, $"No se encontró el ID {request.Id}");
            }

            var response = new AuditoriaPrefijosResponse
            {
                Id = entity.Id,
                Codpre = entity.Codpre,
                Usuario = entity.Usuario,
                Fecha = entity.Fecha,
                Empresa = entity.Empresa,
                Ruc = entity.Ruc
            };

            return new ApiResponse<AuditoriaPrefijosResponse>(Guid.NewGuid(), "OBJECT", response, "Encontrado correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<AuditoriaPrefijosResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
