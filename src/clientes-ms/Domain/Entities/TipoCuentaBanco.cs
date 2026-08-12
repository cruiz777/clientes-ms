using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoCuentaBanco
{
    public int IdCuentaBanco { get; set; }

    public string DesCuentaBanco { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<RpMaeEmpHistorialBanco> RpMaeEmpHistorialBanco { get; set; } = new List<RpMaeEmpHistorialBanco>();
}
