using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoGasto
{
    public int IdTipoGasto { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public string? Monto { get; set; }

    public virtual ICollection<GastosSri> GastosSri { get; set; } = new List<GastosSri>();
}
