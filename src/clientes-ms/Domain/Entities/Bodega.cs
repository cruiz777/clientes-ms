using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Bodega
{
    public long IdBodega { get; set; }

    public long IdProducto { get; set; }

    public string? ClasProducto { get; set; }

    public long? Existencia { get; set; }

    public long? Reservado { get; set; }

    public int? IdLocal { get; set; }

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
