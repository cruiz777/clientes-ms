using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetPrefijosByIdHandler : IRequestHandler<GetPrefijosByIdQuery, ApiResponse<PrefijosResponse>>
{
    private readonly IBaseRepository<Prefijos> _repository;
    public GetPrefijosByIdHandler(IBaseRepository<Prefijos> repository) => _repository = repository;

    public async Task<ApiResponse<PrefijosResponse>> Handle(GetPrefijosByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "OBJECT", null, $"Prefijos with ID {request.Id} not found.");
            return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "OBJECT", new PrefijosResponse(e.IdPrefijos, e.Codpre?.Trim() ?? string.Empty, e.Fecha ?? DateOnly.MinValue, e.FechaCierre ?? DateTime.MinValue, e.Observacion?.Trim() ?? string.Empty, e.Digitos?.Trim() ?? string.Empty, e.Estado ?? false, e.Control ?? 0, e.Ngln??0, e.Bandera ?? 0, e.Facturar?.Trim() ?? string.Empty, e.Codpro?.Trim() ?? string.Empty, e.Nombre?.Trim() ?? string.Empty, e.Fecfac?.Trim() ?? string.Empty, e.ReferenciaInterna?.Trim() ?? string.Empty, e.Prefijosgs1?.Trim() ?? string.Empty, e.OrigenPrefijo?.Trim() ?? string.Empty, e.Orden??0, e.ClientesCodigo ?? 0), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<PrefijosResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}