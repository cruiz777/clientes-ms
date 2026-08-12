using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPagoLiquidacion
{
    public long IdFormaPagoLiq { get; set; }

    public long IdCabLiquidacion { get; set; }

    public string Numliquida { get; set; } = null!;

    public long IdFormaPagoSri { get; set; }

    public string Codigofpago { get; set; } = null!;

    public double Valor { get; set; }

    public int Plazo { get; set; }

    public virtual CabeceraLiquidacion IdCabLiquidacionNavigation { get; set; } = null!;

    public virtual FormaPagoSri IdFormaPagoSriNavigation { get; set; } = null!;
}
