using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoAsiento
{
    public long IdTipoAsiento { get; set; }

    public string TipAsiento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<CabeceraMaestro> CabeceraMaestro { get; set; } = new List<CabeceraMaestro>();
}
