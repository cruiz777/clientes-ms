using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpRegimen
{
    public long IdRegimen { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
