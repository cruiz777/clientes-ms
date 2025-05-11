using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoLocalizacion
{
    public long IdTipoLocalizacion { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();
}
