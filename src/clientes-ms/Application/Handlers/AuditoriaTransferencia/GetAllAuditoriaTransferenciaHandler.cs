using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllAuditoriaTransferenciaHandler : IRequestHandler<GetAllAuditoriaTransferenciaQuery, ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;
    public GetAllAuditoriaTransferenciaHandler(IBaseRepository<AuditoriaTransferencia> repository) => _repository = repository;

    public async Task<ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>> Handle(GetAllAuditoriaTransferenciaQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = (await _repository.GetAllAsync()).Select(MapToResponse);
            return new ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>(Guid.NewGuid(), "LIST", result, "Retrieved successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }

    private static AuditoriaTransferenciaResponse MapToResponse(AuditoriaTransferencia e) => new(e.IdTransferenciaPrefijo,
    e.ClientesCodigoOrigen ?? 0,
    e.ClientesCodigoDestino ?? 0,
    e.Fecha ?? DateTime.Now,
    e.IdPrefijos ?? 0,
    e.Tipo ?? string.Empty,
    e.IdUsuario ?? 0,
    e.ClientesCodigoOrigenNavigation?.Nomcli ?? string.Empty,
    e.ClientesCodigoDestinoNavigation?.Nomcli ?? string.Empty,
    e.IdUsuarioNavigation?.NombreUsuario ?? string.Empty,
    e.IdPrefijosNavigation?.Codpre ?? string.Empty);
}