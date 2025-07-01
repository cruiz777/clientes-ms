using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Cupones;

public record GetCuponReportQuery(
    long? IdPrefijo,
    bool? Estado,
    DateTime? FechaDesde,
    DateTime? FechaHasta,
    string? OperadorFecha
) : IRequest<ApiResponse<List<CuponResponse>>>;
