using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoContribuyente1
{
    public int IdTipoContribuyente { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
