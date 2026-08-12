using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PorcentajeIva
{
    public long IdPorIva { get; set; }

    public long? CodigoIva { get; set; }

    public string? Descripcion { get; set; }

    public long? Porcentaje { get; set; }

    public DateTime? Fechainicio { get; set; }

    public DateTime? Fechafin { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; } = new List<DetalleLiquidacion>();

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();
}
