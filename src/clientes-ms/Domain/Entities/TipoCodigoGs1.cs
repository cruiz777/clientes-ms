using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoCodigoGs1
{
    public long IdTipoCodigoGs1 { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; } = new List<ProductoDatosAdicionales>();
}
