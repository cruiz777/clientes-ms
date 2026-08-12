using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class VwSaldoClienteConsolidado
{
    public long? ClienteCodigo { get; set; }

    public decimal? Saldo { get; set; }
}
