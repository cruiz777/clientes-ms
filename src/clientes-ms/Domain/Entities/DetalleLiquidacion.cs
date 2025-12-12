using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleLiquidacion
{
    public string Numliquida { get; set; } = null!;

    public long IdDetalleLiquidacion { get; set; }

    public string? Codpro { get; set; }

    public string? Descripcion { get; set; }

    public double Cantidad { get; set; }

    public double Pvpunit { get; set; }

    public double Iva { get; set; }

    public double Total { get; set; }

    public int Bien { get; set; }

    public int Servicio { get; set; }

    public double Linea { get; set; }

    public string? CtaContable { get; set; }

    public long IdCabLiquidacion { get; set; }

    public string Caja { get; set; } = null!;
}
