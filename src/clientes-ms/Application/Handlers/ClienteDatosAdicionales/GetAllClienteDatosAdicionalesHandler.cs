using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetAllClienteDatosAdicionalesHandler : IRequestHandler<GetAllClienteDatosAdicionalesQuery, ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;

    public GetAllClienteDatosAdicionalesHandler(IBaseRepository<ClienteDatosAdicionales> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>> Handle(GetAllClienteDatosAdicionalesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var datos = await _repository
                .AsQueryable()
                .ToListAsync(cancellationToken);

            var result = datos.Select(MapToResponse);

            return new ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>(
                Guid.NewGuid(),
                "LIST",
                result,
                "Retrieved successfully"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ClienteDatosAdicionalesResponse>>(
                Guid.NewGuid(),
                "ERROR",
                null,
                ex.Message
            );
        }
    }

    private static ClienteDatosAdicionalesResponse MapToResponse(ClienteDatosAdicionales e) => new(
        idDatosAdicionales: e.IdDatosAdicionales,
        expprod: e.Expprod,
        vendeus: e.Vendeus,
        medico: e.Medico,
        gs1ec: e.Gs1ec,
        instagram: e.Instagram,
        facebook: e.Facebook,
        web: e.Web,
        clientesCodigo: e.ClientesCodigo,
        prefijo: e.Prefijo,
        guia: e.Guia,
        estado: e.Estado
    );
}
