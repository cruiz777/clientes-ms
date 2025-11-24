using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Presentacion
{
    public int IdPresentacion { get; set; }

    public string? Descripcion { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
