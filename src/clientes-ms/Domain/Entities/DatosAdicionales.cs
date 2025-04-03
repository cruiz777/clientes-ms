using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DatosAdicionales
{
    public long IdDatosAdicionales { get; set; }

    public int? Expprod { get; set; }

    public int? Gs1ec { get; set; }

    public int? Gs1latam { get; set; }

    public int? Gas1org { get; set; }

    public string? Web { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
}
