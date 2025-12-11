using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleModelo
{
    public double Linea { get; set; }

    public string? Tipolinea { get; set; }

    public double? Columna { get; set; }

    public string? Codpre { get; set; }

    public string? DescCta { get; set; }

    public string? Tipodato { get; set; }

    public double? Lineaux { get; set; }

    public string? IdNota { get; set; }

    public long IdCabModelo { get; set; }
}
