using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Cantones
{
    public long IdCanton { get; set; }

    public long IdProvincia { get; set; }

    public string? Referencia { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Ciudades> Ciudades { get; set; } = new List<Ciudades>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}
