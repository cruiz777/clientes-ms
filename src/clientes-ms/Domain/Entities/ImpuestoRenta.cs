using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ImpuestoRenta
{
    public int IdImpRenta { get; set; }

    public int? Frabas1Ir { get; set; }

    public int? Frabas2Ir { get; set; }

    public decimal? ImpbasIr { get; set; }

    public int? PorexdIr { get; set; }
}
