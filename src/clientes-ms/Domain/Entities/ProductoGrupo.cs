using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoGrupo
{
    public long IdProductoGrupo { get; set; }

    public double? Codgru { get; set; }

    public string? Desgru { get; set; }

    public string? Sec { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
