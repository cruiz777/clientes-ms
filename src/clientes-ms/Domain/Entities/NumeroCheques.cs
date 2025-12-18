using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NumeroCheques
{
    public long IdNroCheque { get; set; }

    public string CuentaBanco { get; set; } = null!;

    public double? NumCheque { get; set; }

    public double? NumTra { get; set; }

    public string? Estado { get; set; }

    public bool? Ocupado { get; set; }

    public double NumTragGlobal { get; set; }

    public long IdEmpresa { get; set; }

    public long IdPlanCuentas { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual PlanCuentas IdPlanCuentasNavigation { get; set; } = null!;
}
