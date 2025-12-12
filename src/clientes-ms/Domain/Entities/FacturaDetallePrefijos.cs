using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FacturaDetallePrefijos
{
    public int IdPagosPrefijo { get; set; }

    public long ClientesCodigo { get; set; }

    public string? CodigoPrefijo { get; set; }

    public DateOnly? PeriodoDesde { get; set; }

    public DateOnly? PeriodoHasta { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public string? Numnota { get; set; }

    public DateOnly? FechaFactura { get; set; }
}
