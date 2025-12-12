using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PlazoTarjeta
{
    public int IdPlazo { get; set; }

    public string CodPlazo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Anticipo> Anticipo { get; set; } = new List<Anticipo>();
}
