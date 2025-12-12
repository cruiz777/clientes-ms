using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoUbicacionBodega
{
    public long IdProductoUbicacion { get; set; }

    public long IdProducto { get; set; }

    public int IdLocal { get; set; }

    public int? IdColumna { get; set; }

    public int? IdNivel { get; set; }

    public int? IdArea { get; set; }

    public virtual UbicacionArea? IdAreaNavigation { get; set; }

    public virtual UbicacionColumna? IdColumnaNavigation { get; set; }

    public virtual Locales IdLocalNavigation { get; set; } = null!;

    public virtual UbicacionNivel? IdNivelNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
