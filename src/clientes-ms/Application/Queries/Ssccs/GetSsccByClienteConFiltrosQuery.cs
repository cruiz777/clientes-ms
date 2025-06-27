using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Ssccs;

public record GetSsccByClienteConFiltrosQuery(
    int IdCliente,
    int Page = 1,
    int PageSize = 50,
    int? IdPrefijo = null,
    string? Busqueda = null,
    string? Empaque = null,
    string? SerialDesde = null,
    string? SerialHasta = null,
    bool? Estado = null,
    DateTime? FechaDesde = null,
    DateTime? FechaHasta = null
) : IRequest<ApiResponse<PaginationResponse<SsccResponse>>>;