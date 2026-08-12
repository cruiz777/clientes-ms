using clientes_ms.Application.Records.Response;
using MediatR;
using System.Collections.Generic;

namespace clientes_ms.Application.Queries.Clientes
{
    public class GetClientesPaged
        : IRequest<ApiResponse<IEnumerable<ClientesExploradorResponse>>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? BusquedaGeneral { get; set; }

        public string? PrefijoBusqueda { get; set; }

        public GetClientesPaged()
        {
        }

        public GetClientesPaged(
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