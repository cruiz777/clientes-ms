using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Stocks
{
    public long IdStock { get; set; }

    public long IdProducto { get; set; }

    public int IdLocal { get; set; }

    public double? StockMin { get; set; }

    public double? StockMax { get; set; }

    public double? Cantidad { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Locales IdLocalNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
