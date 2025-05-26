using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoSubDivision
{
    public double Codsub { get; set; }

    public string IdEmpresa { get; set; } = null!;

    public string? Dessub { get; set; }

    public double? Coddiv { get; set; }

    public int? PeaCodigoHis { get; set; }

    public bool? Estado { get; set; }
}
