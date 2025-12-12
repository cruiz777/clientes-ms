using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Subproyectos
{
    public long IdSubproyecto { get; set; }

    public long? IdProyecto { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual Proyectos? IdProyectoNavigation { get; set; }
}
