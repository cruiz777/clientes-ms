using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDivision
{
    public double Coddiv { get; set; }

    public long IdEmpresa { get; set; }

    public string? Desdiv { get; set; }

    public bool? Estado { get; set; }
}
