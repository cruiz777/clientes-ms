using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpTipoDiscapacidad
{
    public long IdTipoDiscapacidad { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cargas> Cargas { get; set; } = new List<Cargas>();

    public virtual ICollection<RpEmpleadosDiscapacidad> RpEmpleadosDiscapacidad { get; set; } = new List<RpEmpleadosDiscapacidad>();
}
