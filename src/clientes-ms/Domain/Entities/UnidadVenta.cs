using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class UnidadVenta
{
    public int IdUnidadVenta { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Cantidad { get; set; }

    public bool Status { get; set; }
}
