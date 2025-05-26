using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDepartamento
{
    public double Coddep { get; set; }

    public string IdEmpresa { get; set; } = null!;

    public string? Desdep { get; set; }

    public double? Codsub { get; set; }

    public bool? Estado { get; set; }
}
