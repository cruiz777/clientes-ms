using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Paises
{
    public long IdPais { get; set; }

    public string? Codzona { get; set; }

    public string? Nombre { get; set; }

    public double? CodigoArea { get; set; }

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
