using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoNominaEsp
{
    public int IdTipoNomEsp { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<NominaEspecial> NominaEspecial { get; set; } = new List<NominaEspecial>();
}
