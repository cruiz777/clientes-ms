using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class UbicacionArea
{
    public int IdArea { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ProductoUbicacionBodega> ProductoUbicacionBodega { get; set; } = new List<ProductoUbicacionBodega>();
}
