using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraModelo
{
    public string? Nombre { get; set; }

    public string? TipoBalance { get; set; }

    public string? ControlB { get; set; }

    public long IdCabModelo { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual ICollection<PlanCuentas> PlanCuentas { get; set; } = new List<PlanCuentas>();
}
