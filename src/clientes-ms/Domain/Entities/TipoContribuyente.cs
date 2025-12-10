using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoContribuyente
{
    public long IdTipoContribuyente { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Codigoalterno { get; set; } = null!;

    public virtual ICollection<CodigosContables> CodigosContables { get; set; } = new List<CodigosContables>();
}
