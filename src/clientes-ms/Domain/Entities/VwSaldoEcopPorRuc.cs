using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class VwSaldoEcopPorRuc
{
    public string? Ruc { get; set; }

    public decimal? Saldo { get; set; }
}
