using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoProveedor
{
    public int IdTipoProveedor { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? CodigoCuentaContable { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
