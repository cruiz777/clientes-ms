using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllEstadoEmpresaHandler : IRequestHandler<GetAllEstadoEmpresaQuery, ApiResponse<IEnumerable<EstadoEmpresaResponse>>>
{
    private readonly IBaseRepository<EstadoEmpresa> _repository;
    public GetAllEstadoEmpresaHandler(IBaseRepository<EstadoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<EstadoEmpresaResponse>>> Handle(GetAllEstadoEmpresaQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<EstadoEmpresaResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<EstadoEmpresaResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static EstadoEmpresaResponse MapToResponse(EstadoEmpresa e) => new(e.IdEstadoEmpresa, e.Nombre?.Trim() ?? string.Empty, e.Fecha??DateOnly.MinValue,e.EmpresaCodigo??0);
}