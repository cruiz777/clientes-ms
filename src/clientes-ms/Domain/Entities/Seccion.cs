using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Seccion
{
    public long IdProductoSeccion { get; set; }

    public double? Codsec { get; set; }

    public long? IdProductoDepartamento { get; set; }

    public virtual ProductoDepartamento? IdProductoDepartamentoNavigation { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
