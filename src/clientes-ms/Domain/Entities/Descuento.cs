using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Descuento
{
    public long IdDescuento { get; set; }

    public string? Descripcion { get; set; }

    public int Valor { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
