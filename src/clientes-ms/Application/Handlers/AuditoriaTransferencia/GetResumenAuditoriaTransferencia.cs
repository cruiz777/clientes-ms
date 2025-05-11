using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


public class GetResumenAuditoriaTransferenciaHandler : IRequestHandler<GetAuditoriaTransferenciaByResumen, ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>>
{
    private readonly IBaseRepository<AuditoriaTransferencia> _repository;

    public GetResumenAuditoriaTransferenciaHandler(IBaseRepository<AuditoriaTransferencia> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>> Handle(GetAuditoriaTransferenciaByResumen request, CancellationToken cancellationToken)
    {
        try
        {
            var auditorias = await _repository
                .AsQueryable()
                .Include(e => e.ClientesCodigoOrigenNavigation)
                .Include(e => e.ClientesCodigoDestinoNavigation)
                .Include(e => e.IdPrefijosNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .ToListAsync(cancellationToken);

            var result = auditorias.Select(a => new AuditoriaTransferenciaResponse(
                IdTraferenciaPrefijo: a.IdTransferenciaPrefijo,
                ClientesCodigoOrigen: a.ClientesCodigoOrigen ?? 0,
                ClientesCodigoDestino: a.ClientesCodigoDestino ?? 0,
                Fecha: a.Fecha ?? DateTime.MinValue,
                IdPrefijos: a.IdPrefijos ?? 0,
                Tipo: a.Tipo ?? string.Empty,
                IdUsuario: a.IdUsuario ?? 0,
                origen: a.ClientesCodigoOrigenNavigation?.Nomcli ?? string.Empty,
                destino: a.ClientesCodigoDestinoNavigation?.Nomcli ?? string.Empty,
                usuario: a.IdUsuarioNavigation?.NombreUsuario ?? string.Empty,
                prefijo: a.IdPrefijosNavigation?.Codpre ?? string.Empty
            )).ToList();

            return new ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} registros.",
                result.Count
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<AuditoriaTransferenciaResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener las transferencias: {ex.Message}"
            );
        }
    }
}
