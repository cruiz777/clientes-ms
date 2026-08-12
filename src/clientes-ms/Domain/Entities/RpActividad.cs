using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpActividad
{
    public long CodActividad { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool? Estado { get; set; }

    public int? CodRubro { get; set; }
}
