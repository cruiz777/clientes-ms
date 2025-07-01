using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Cupon
{
    public record GetCuponesByClienteConFiltrosQuery(
        long IdCliente,
        int Page = 1,
        int PageSize = 50,
        long? IdPrefijo = null,
        string? Busqueda = null,
        int? SerialDesde = null,
        int? SerialHasta = null,
        bool? Estado = null,
        DateOnly? FechaInicioDesde = null,
        DateOnly? FechaInicioHasta = null,
        DateOnly? FechaCaducidadDesde = null,
        DateOnly? FechaCaducidadHasta = null
    ) : IRequest<ApiResponse<PaginationResponse<CuponResponse>>>;

}
