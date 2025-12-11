using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoComprobanteSri
{
    public string Codtipcomp { get; set; } = null!;

    public string? Destipcomp { get; set; }

    public string? Sustentotrib { get; set; }

    public long IdTipoCompSri { get; set; }

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();
}
