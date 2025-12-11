using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoCuenta
{
    public string Tipcue { get; set; } = null!;

    public string? Destip { get; set; }

    public string? Tranban { get; set; }

    public long IdTipoCuenta { get; set; }
}
