using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoDocumento
{
    public long IdTipoDocumento { get; set; }

    public string? Descripcion { get; set; }

    public string? Referencia { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();
}
