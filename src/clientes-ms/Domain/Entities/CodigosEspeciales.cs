using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CodigosEspeciales
{
    public long Codespecial { get; set; }

    public string? Descespecial { get; set; }

    public virtual ICollection<PlanCuentas> PlanCuentas { get; set; } = new List<PlanCuentas>();
}
