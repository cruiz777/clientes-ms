using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoSeccion
{
    public double Codsec { get; set; }

    public long IdEmpresa { get; set; }

    public double? Coddep { get; set; }

    public bool? Estado { get; set; }
}
