using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

public class GetAuditoriaTransferenciaByIdHandler : IRequestHandler<GetAuditoriaTransferenciaByIdQuery, ApiResponse<AuditoriaTransferenciaResponse>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;

    public GetAuditoriaTransferenciaByIdHandler(IBaseRepository<AuditoriaTransferencia> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<AuditoriaTransferenciaResponse>> Handle(GetAuditoriaTransferenciaByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository.GetByIdAsync(request.Id);

            if (e == null)
                return new ApiResponse<AuditoriaTransferenciaResponse>(
                    Guid.NewGuid(),
                    "NOT_FOUND",
                    null,
                    $"Auditoría con ID {request.Id} no encontrada.");

            var response = new AuditoriaTransferenciaResponse(
                idTraferenciaPrefijo: e.IdTransferenciaPrefijo,
                clientesCodigoOrigen: e.ClientesCodigoOrigen ?? 0,
                clientesCodigoDestino: e.ClientesCodigoDestino ?? 0,
                fecha: e.Fecha ?? DateTime.Now,
                idPrefijos: e.IdPrefijos ?? 0,
                tipo: e.Tipo ?? string.Empty,
                idUsuario: e.IdUsuario ?? 0,
                origen: e.ClientesCodigoOrigenNavigation?.Nomcli ?? string.Empty,
                destino: e.ClientesCodigoDestinoNavigation?.Nomcli ?? string.Empty,
                usuario: e.IdUsuarioNavigation?.NombreUsuario ?? string.Empty,
                prefijo: e.IdPrefijosNavigation?.Codpre ?? string.Empty,
                rucOrigen: e.ClientesCodigoOrigenNavigation?.Ruc ?? string.Empty,
                rucDestino: e.ClientesCodigoDestinoNavigation?.Ruc ?? string.Empty
            );

            return new ApiResponse<AuditoriaTransferenciaResponse>(
                Guid.NewGuid(),
                "SUCCESS",
                response,
                "Auditoría encontrada correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<AuditoriaTransferenciaResponse>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener auditoría: {ex.Message}");
        }
    }
}
