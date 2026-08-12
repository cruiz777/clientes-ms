using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleActivoFijo
{
    public long IdDetalleActivoFijo { get; set; }

    public int? Expira { get; set; }

    public long? IdPlanCuentas { get; set; }

    public long CodigoAf { get; set; }

    public string? Descripcion { get; set; }

    public string? Feccompra { get; set; }

    public string? Proveedor { get; set; }

    public string? Comprobante { get; set; }

    public double? Valorcompra { get; set; }

    public double? Vidautil { get; set; }

    public double? DepreciacionAnual { get; set; }

    public double? DepreMensual { get; set; }

    public double? ValorResidual { get; set; }

    public string FechaConsulta { get; set; } = null!;

    public string? NombreCuenta { get; set; }

    public int Dias { get; set; }

    public int? Estado { get; set; }

    public string? Asiento { get; set; }

    public DateOnly? NuevaFechaConsulta { get; set; }

    public virtual ActivoFijo CodigoAfNavigation { get; set; } = null!;

    public virtual PlanCuentas? IdPlanCuentasNavigation { get; set; }
}
