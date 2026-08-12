using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpVacaciones
{
    public long IdVacacion { get; set; }

    public long IdEmpleado { get; set; }

    public DateOnly? Feinivac { get; set; }

    public DateOnly? Fefinvac { get; set; }
}
