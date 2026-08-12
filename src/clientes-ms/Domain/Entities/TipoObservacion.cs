using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoObservacion
{
    public int IdTipoObservacion { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Observaciones> Observaciones { get; set; } = new List<Observaciones>();
}
