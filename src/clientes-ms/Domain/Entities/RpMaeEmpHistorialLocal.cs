using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpHistorialLocal
{
    public long IdHistorialLocal { get; set; }

    public long IdEmpleado { get; set; }

    public long? IdZona { get; set; }

    public long? IdLocal { get; set; }

    public long? IdCiudadTrabajo { get; set; }

    public DateOnly FechaDesde { get; set; }

    public DateOnly? FechaHasta { get; set; }

    public virtual Ciudades? IdCiudadTrabajoNavigation { get; set; }
}
