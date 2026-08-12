using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpNivelInstruccion
{
    public long IdNivelInstruccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<RpMaeEmpFormacion> RpMaeEmpFormacion { get; set; } = new List<RpMaeEmpFormacion>();
}
