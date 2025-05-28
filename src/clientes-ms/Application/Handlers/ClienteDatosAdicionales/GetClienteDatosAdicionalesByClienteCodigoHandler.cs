using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetClienteDatosAdicionalesByClienteCodigoHandler : IRequestHandler<GetClienteDatosAdicionalesByClienteCodigoQuery, ApiResponse<ClienteDatosAdicionalesResponse>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;
    public GetClienteDatosAdicionalesByClienteCodigoHandler(IBaseRepository<ClienteDatosAdicionales> repository) => _repository = repository;

    public async Task<ApiResponse<ClienteDatosAdicionalesResponse>> Handle(GetClienteDatosAdicionalesByClienteCodigoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var e = await _repository
                .AsQueryable()
                .FirstOrDefaultAsync(tc => tc.ClientesCodigo == request.ClientesCodigo, cancellationToken);

            if (e == null)
                return new ApiResponse<ClienteDatosAdicionalesResponse>(Guid.NewGuid(), "OBJECT", null, $"ClienteDatosAdicionales con código de cliente {request.ClientesCodigo} no encontrado.");

            var response = new ClienteDatosAdicionalesResponse(
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

            return new ApiResponse<ClienteDatosAdicionalesResponse>(Guid.NewGuid(), "OBJECT", response, "Success");
        }
        catch (Exception ex)
        {
            return new ApiResponse<ClienteDatosAdicionalesResponse>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}

