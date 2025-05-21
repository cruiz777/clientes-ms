using clientes_ms.Application.Records.Response;
using Microsoft.EntityFrameworkCore;
using MediatR;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;

public class GetResumenClienteDatosAdicionalesHandler : IRequestHandler<GetClienteDatosAdicionalesByResumen, ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;

    public GetResumenClienteDatosAdicionalesHandler(IBaseRepository<ClienteDatosAdicionales> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>> Handle(GetClienteDatosAdicionalesByResumen request, CancellationToken cancellationToken)
    {
        try
        {
            var datos = await _repository.AsQueryable().ToListAsync(cancellationToken);

            var result = datos.Select(t => new ClienteDatosAdicionalesResponse(
                idDatosAdicionales: t.IdDatosAdicionales,
                expprod: t.Expprod,
                vendeus: t.Vendeus,
                medico: t.Medico,
                gs1ec: t.Gs1ec,
                instagram: t.Instagram,
                facebook: t.Facebook,
                web: t.Web,
                clientesCodigo: t.ClientesCodigo ?? 0,
                prefijo: t.Prefijo ?? false,
                guia: t.Guia ?? false,
                estado: t.Estado ?? false
            )).ToList();

            return new ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                $"Se encontraron {result.Count} registro(s) de datos adicionales.",
                result.Count
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                $"Error al obtener los datos adicionales del cliente: {ex.Message}"
            );
        }
    }
}
