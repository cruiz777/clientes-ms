using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllGrupoEmpresaHandler : IRequestHandler<GetAllGrupoEmpresaQuery, ApiResponse<IEnumerable<GrupoEmpresaResponse>>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    public GetAllGrupoEmpresaHandler(IBaseRepository<GrupoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<GrupoEmpresaResponse>>> Handle(GetAllGrupoEmpresaQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<GrupoEmpresaResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<GrupoEmpresaResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static GrupoEmpresaResponse MapToResponse(GrupoEmpresa e) => new(e.IdGrupoEmpresa, e.Codigo?.Trim() ?? string.Empty,e.Nombre?? string.Empty,e.Inscripcion ?? 0.0,e.Asignacion ?? 0.0,e.Mantenimiento ??0.0,e.Fecha ?? DateOnly.MinValue, e.ProductoInscripcion?? string.Empty, e.ProductoMantenimiento?? string.Empty, e.ProductoAsignacion?? string.Empty, e.AsignacionDolar ?? 0.0,e.MantenimientoDolar ?? 0.0,e.InscripcionDolar ?? 0.0,e.ValorAnual ?? 0.0,e.Estado);
}