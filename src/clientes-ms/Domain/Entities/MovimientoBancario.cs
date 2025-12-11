using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class MovimientoBancario
{
    public string Movimiento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public double? Porcentaje { get; set; }

    public double? Condicion { get; set; }

    public long IdMovBancario { get; set; }

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();
}
