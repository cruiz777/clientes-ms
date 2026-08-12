using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpEmpresaComplementaria
{
    public long IdEmpresaComplementaria { get; set; }

    public string Empresa { get; set; } = null!;

    public string? Ruc { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
