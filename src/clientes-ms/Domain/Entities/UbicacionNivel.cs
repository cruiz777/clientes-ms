using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

/// <summary>
/// Nivel o fila en el estante
/// </summary>
public partial class UbicacionNivel
{
    public int IdNivel { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Orden { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ProductoUbicacionBodega> ProductoUbicacionBodega { get; set; } = new List<ProductoUbicacionBodega>();
}
