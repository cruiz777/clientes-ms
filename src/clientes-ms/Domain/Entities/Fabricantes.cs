using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Fabricantes
{
    public int IdFabricante { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
