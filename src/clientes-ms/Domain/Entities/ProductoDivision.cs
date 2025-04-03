using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDivision
{
    public long IdProductoDivision { get; set; }

    public double? Coddiv { get; set; }

    public string? Desdiv { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<ProductoDepartamento> ProductoDepartamento { get; set; } = new List<ProductoDepartamento>();

    public virtual ICollection<ProductoSubDivision> ProductoSubDivision { get; set; } = new List<ProductoSubDivision>();
}
