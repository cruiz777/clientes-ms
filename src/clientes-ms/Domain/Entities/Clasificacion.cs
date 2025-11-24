using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Clasificacion
{
    public long IdClasificacion { get; set; }

    public string? Descripcion { get; set; }

    public string? CodigoCuenta { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<FormaPago> FormaPago { get; set; } = new List<FormaPago>();
}
