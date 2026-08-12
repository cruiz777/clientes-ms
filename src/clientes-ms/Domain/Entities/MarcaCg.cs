using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class MarcaCg
{
    public long IdMarca { get; set; }

    public string? Tipmar { get; set; }

    public string? Desmar { get; set; }

    public string? Marca { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijo { get; set; } = new List<ActivoFijo>();
}
