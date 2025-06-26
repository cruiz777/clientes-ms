using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

namespace clientes_ms.Application.Handlers.Ssccs
{
    public class GetSsccByNumeroHandler : IRequestHandler<GetSsccByNumeroQuery, ApiResponse<SsccResponse>>
    {
        private readonly IBaseRepository<Sscc> _ssccRepository;

        public GetSsccByNumeroHandler(IBaseRepository<Sscc> ssccRepository)
        {
            _ssccRepository = ssccRepository;
        }

        public async Task<ApiResponse<SsccResponse>> Handle(GetSsccByNumeroQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sscc = await _ssccRepository
                    .FirstOrDefaultAsync(x => x.SsccCompleto == request.NumeroSscc);

                if (sscc is null)
                {
                    return new ApiResponse<SsccResponse>(
                        Guid.NewGuid(),
                        "ERROR",
                        null,
                        "No se encontró el SSCC con el número proporcionado"
                    );
                }

                var response = new SsccResponse(
                    sscc.IdSscc,
                    sscc.IdPrefijo,
                    sscc.IdCliente,
                    sscc.Indicador,
                    sscc.Serial,
                    sscc.DigitoControl,
                    sscc.SsccCompleto,
                    sscc.Serie,
                    sscc.SecuenciaInicio,
                    sscc.SecuenciaFin,
                    sscc.TotalGenerado,
                    sscc.ProductoCodificado,
                    sscc.Estado,
                    sscc.Usuario,
                    sscc.FechaCreacion
                );

                return new ApiResponse<SsccResponse>(
                    Guid.NewGuid(),
                    "SUCCESS",
                    response,
                    "SSCC encontrado exitosamente"
                );
            }
            catch (Exception ex)
            {
                return new ApiResponse<SsccResponse>(
                    Guid.NewGuid(),
                    "ERROR",
                    null,
                    $"Ocurrió un error al buscar el SSCC: {ex.Message}"
                );
            }
        }
    }
}
