using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDepartamento
{
    public long IdProductoDepartamento { get; set; }

    public double? Coddep { get; set; }

    public string? Desdep { get; set; }

    public long? IdProductoDivision { get; set; }

    public virtual ProductoDivision? IdProductoDivisionNavigation { get; set; }

    public virtual ICollection<Seccion> Seccion { get; set; } = new List<Seccion>();
}
