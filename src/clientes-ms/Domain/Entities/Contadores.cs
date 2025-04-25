using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Contadores
{
    public long IdContador { get; set; }

    public long EmpresaCodigo { get; set; }

    public long IdPersona { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public bool Status { get; set; }

    public virtual Empresas EmpresaCodigoNavigation { get; set; } = null!;

    public virtual Personas IdPersonaNavigation { get; set; } = null!;
}
