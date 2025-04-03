using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Pais
{
    public long PaisCodigo { get; set; }

    public string? PaisCodzona { get; set; }

    public string? PaisNombre { get; set; }

    public double? PaisCodigoArea { get; set; }

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
