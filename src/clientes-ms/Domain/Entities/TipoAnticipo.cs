using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoAnticipo
{
    public int IdTipoAnticipo { get; set; }

    public string? Descripcion { get; set; }

    public string? CtaContable { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Anticipo> Anticipo { get; set; } = new List<Anticipo>();
}
