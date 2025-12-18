using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NivelPlanCuentas
{
    public long IdNivel { get; set; }

    public string? Descripcion { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<PlanCuentas> PlanCuentas { get; set; } = new List<PlanCuentas>();
}
