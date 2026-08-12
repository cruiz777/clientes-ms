using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpCargaFamiliar
{
    public long IdCarga { get; set; }

    public int NCarga { get; set; }

    public int NCanastaFam { get; set; }

    public decimal GastoMaxDeduc { get; set; }

    public decimal RebajaImp { get; set; }
}
