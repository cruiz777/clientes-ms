using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Sector
{
    public long IdSector { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; } = new List<ProductoDatosAdicionales>();
}
