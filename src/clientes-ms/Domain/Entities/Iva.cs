using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Iva
{
    public long IdIva { get; set; }

    public long CodigoIva { get; set; }

    public string Descripcion { get; set; } = null!;

    public long Porcentaje { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public bool? Principal { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
