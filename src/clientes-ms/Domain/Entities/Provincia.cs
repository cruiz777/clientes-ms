using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Provincia
{
    public long IdProvincia { get; set; }

    public long IdPais { get; set; }

    public string? Referencia { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cantones> Cantones { get; set; } = new List<Cantones>();

    public virtual Paises IdPaisNavigation { get; set; } = null!;
}
