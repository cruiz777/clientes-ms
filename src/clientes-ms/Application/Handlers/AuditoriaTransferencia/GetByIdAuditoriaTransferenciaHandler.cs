using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class GetAuditoriaTransferenciaByIdHandler : IRequestHandler<GetAuditoriaTransferenciaByIdQuery, ApiResponse<AuditoriaTransferenciaResponse>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;
    public GetAuditoriaTransferenciaByIdHandler(IBaseRepository<AuditoriaTransferencia> repository) => _repository = repository;

    public async Task<ApiResponse<AuditoriaTransferenciaResponse>> Handle(GetAuditoriaTransferenciaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);
            if (e == null) return new ApiResponse<AuditoriaTransferenciaResponse>(Guid.NewGuid(), "OBJECT", null, $"AuditoriaTransferencia with ID {request.Id} not found.");
            return new ApiResponse<AuditoriaTransferenciaResponse>(Guid.NewGuid(), "OBJECT", new AuditoriaTransferenciaResponse(
                e.IdTransferenciaPrefijo,
    e.ClientesCodigoOrigen ?? 0,
    e.ClientesCodigoDestino ?? 0,
    e.Fecha ?? DateTime.Now,
    e.IdPrefijos ?? 0,
    e.Tipo ?? string.Empty,
    e.IdUsuario ?? 0,
    e.ClientesCodigoOrigenNavigation?.Nomcli ?? string.Empty,
    e.ClientesCodigoDestinoNavigation?.Nomcli ?? string.Empty,
    e.IdUsuarioNavigation?.NombreUsuario ?? string.Empty,
    e.IdPrefijosNavigation?.Codpre ?? string.Empty
                ), "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<AuditoriaTransferenciaResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}