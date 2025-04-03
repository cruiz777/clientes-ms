using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoSubDivision
{
    public long IdProductoSubDivision { get; set; }

    public string? Dessub { get; set; }

    public long? IdProductoDivision { get; set; }

    public int? PeaCodigoHis { get; set; }

    public virtual ProductoDivision? IdProductoDivisionNavigation { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
