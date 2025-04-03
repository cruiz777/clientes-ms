using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Entidad
{
    public long IdEntidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Status { get; set; }
}
