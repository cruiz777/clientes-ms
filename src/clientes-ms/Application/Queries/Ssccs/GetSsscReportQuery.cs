using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Queries.Ssccs;

public record GetSsccReportQuery(
    long? IdPrefijo,
    bool? Estado,
    DateTime? FechaDesde,
    DateTime? FechaHasta,
    string? OperadorFecha
) : IRequest<ApiResponse<List<SsccResponse>>>;

