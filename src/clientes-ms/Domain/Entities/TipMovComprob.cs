using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipMovComprob
{
    public long IdTipComp { get; set; }

    public string? DescripcionTipComp { get; set; }

    public long? IdTipoCompSri { get; set; }

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual TipoComprobanteSri? IdTipoCompSriNavigation { get; set; }
}
