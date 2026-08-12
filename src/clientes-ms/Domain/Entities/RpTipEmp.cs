using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpTipEmp
{
    public long IdTipemp { get; set; }

    public string DesTipemp { get; set; } = null!;

    public string? CtaCbleSue1 { get; set; }

    public string? CtaCbleSue2 { get; set; }

    public string? CtaCbleSue3 { get; set; }

    public string? CtaCbleSue4 { get; set; }

    public string? CtaCbleSue5 { get; set; }

    public bool SwRelDep { get; set; }

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
