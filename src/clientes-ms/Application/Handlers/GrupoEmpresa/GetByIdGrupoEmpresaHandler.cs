using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetGrupoEmpresaByIdHandler : IRequestHandler<GetGrupoEmpresaByIdQuery, ApiResponse<GrupoEmpresaResponse>>
{
    private readonly IBaseRepository<GrupoEmpresa> _repository;
    public GetGrupoEmpresaByIdHandler(IBaseRepository<GrupoEmpresa> repository) => _repository = repository;

    public async Task<ApiResponse<GrupoEmpresaResponse>> Handle(GetGrupoEmpresaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<GrupoEmpresaResponse>(Guid.NewGuid(), "OBJECT", null, $"GrupoEmpresa with ID {request.Id} not found.");
            return new ApiResponse<GrupoEmpresaResponse>(Guid.NewGuid(), "OBJECT", new GrupoEmpresaResponse(e.IdGrupoEmpresa, e.Codigo?.Trim() ?? string.Empty, e.Nombre ?? string.Empty, e.Inscripcion ?? 0.0, e.Asignacion ?? 0.0, e.Mantenimiento ?? 0.0, e.Fecha ?? DateOnly.MinValue, e.ProductoInscripcion?? string.Empty, e.ProductoMantenimiento?? string.Empty, e.ProductoAsignacion?? string.Empty, e.AsignacionDolar ?? 0.0, e.MantenimientoDolar ?? 0.0, e.InscripcionDolar ?? 0.0, e.ValorAnual ?? 0.0,e.Estado), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<GrupoEmpresaResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}