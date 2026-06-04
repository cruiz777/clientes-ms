using MediatR;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.Application.Handlers.Cliente
{
    public class GetResumenTipoClienteAnioMesDesafiliadasQuery
        : IRequest<ApiResponse<ResumenTipoClienteAnioMesResponse>>
    {
        public int Anio { get; }
        public int Mes { get; }

        public GetResumenTipoClienteAnioMesDesafiliadasQuery(int anio, int mes)
        {
            Anio = anio;
            Mes = mes;
        }
    }
}