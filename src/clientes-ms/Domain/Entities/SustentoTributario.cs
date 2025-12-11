using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class SustentoTributario
{
    public string Codsustento { get; set; } = null!;

    public string? Dessustento { get; set; }

    public long IdSustentoTrib { get; set; }

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();
}
