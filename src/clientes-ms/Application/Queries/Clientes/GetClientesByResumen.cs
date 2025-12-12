using clientes_ms.Application.Records.Response;
using MediatR;
using System.Collections.Generic;

namespace clientes_ms.Application.Queries.Clientes
{
    public class GetClientesByResumen : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? BusquedaGeneral { get; set; }
        public string? PrefijoBusqueda { get; set; }

        public GetClientesByResumen(
            int pageNumber,
            int pageSize,
            string? busquedaGeneral = null,
            string? prefijoBusqueda = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            BusquedaGeneral = busquedaGeneral;
            PrefijoBusqueda = prefijoBusqueda;
        }
    }
}
