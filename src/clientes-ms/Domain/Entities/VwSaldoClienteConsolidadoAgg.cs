using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class VwSaldoClienteConsolidadoAgg
{
    public long? ClienteCodigo { get; set; }

    public decimal? Saldo { get; set; }
}
