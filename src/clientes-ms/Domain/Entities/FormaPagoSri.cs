using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPagoSri
{
    public long IdFormaPagoSri { get; set; }

    public string Descripcion { get; set; } = null!;

    public string CodigoSri { get; set; } = null!;

    public virtual ICollection<FormaPagoLiquidacion> FormaPagoLiquidacion { get; set; } = new List<FormaPagoLiquidacion>();
}
