using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpRubros
{
    public long CodRubro { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }
}
