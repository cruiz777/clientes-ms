using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Imprentamensual
{
    public long IdEmpleado { get; set; }

    public DateOnly Fecha { get; set; }

    public string Periodo { get; set; } = null!;

    public int Anio { get; set; }

    public decimal IngresosGrabados { get; set; }

    public decimal Descuentoless { get; set; }

    public decimal IngresosExento { get; set; }

    public decimal Descuento { get; set; }

    public decimal ValorRetenido { get; set; }

    public long IdImprentaMesual { get; set; }
}
