using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpFomaPago
{
    public long IdFormaPago { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<RpMaeEmpHistorialBanco> RpMaeEmpHistorialBanco { get; set; } = new List<RpMaeEmpHistorialBanco>();
}
