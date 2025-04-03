using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Departamentos
{
    public long IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
