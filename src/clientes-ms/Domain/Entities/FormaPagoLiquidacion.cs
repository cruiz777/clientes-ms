using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPagoLiquidacion
{
    public string Numliquida { get; set; } = null!;

    public long IdFormaPagoLiq { get; set; }

    public double Valor { get; set; }
}
