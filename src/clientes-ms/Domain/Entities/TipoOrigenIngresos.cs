using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoOrigenIngresos
{
    public long SicTipoOrigenIngresosCodigo { get; set; }

    public string? SicTipoOrigenIngresosNombre { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
}
