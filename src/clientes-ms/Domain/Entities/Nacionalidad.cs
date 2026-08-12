using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Nacionalidad
{
    public long IdNacionalidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
