using MediatR;
using clientes_ms.Application.Records.Response;
using System.Collections.Generic;

namespace clientes_ms.Application.Queries.Clientes
{
    // ⚠️ nombres coinciden con el querystring: pageNumber, pageSize, busquedaGeneral, prefijoBusqueda
    public class GetClientesPaged : IRequest<ApiResponse<IEnumerable<ClientesResponse>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? BusquedaGeneral { get; set; }
        public string? PrefijoBusqueda { get; set; }
    }
}
