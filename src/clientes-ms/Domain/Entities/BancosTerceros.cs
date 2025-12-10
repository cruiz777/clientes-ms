using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class BancosTerceros
{
    public long IdBancosTerceros { get; set; }

    public string? Descripcion { get; set; }

    public int Codban { get; set; }

    public virtual ICollection<Anticipo> Anticipo { get; set; } = new List<Anticipo>();
}
