using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CierrePeriodo
{
    public long IdCierrePeriodo { get; set; }

    public DateOnly Fecha { get; set; }

    public DateTime FecEmi { get; set; }

    public long IdUsuario { get; set; }

    public string Periodo { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }
}
