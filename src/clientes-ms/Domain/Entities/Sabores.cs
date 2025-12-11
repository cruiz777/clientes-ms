using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Sabores
{
    public int IdSabor { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
