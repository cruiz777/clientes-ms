using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPagoSri
{
    public long IdFormaPagoSri { get; set; }

    public string? Descripcion { get; set; }

    public string? CodigoSri { get; set; }

    public virtual ICollection<FormaPago> FormaPago { get; set; } = new List<FormaPago>();
}
