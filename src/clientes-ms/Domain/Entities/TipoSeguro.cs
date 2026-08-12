using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoSeguro
{
    public int IdTipoSeguro { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Empresas> Empresas { get; set; } = new List<Empresas>();
}
