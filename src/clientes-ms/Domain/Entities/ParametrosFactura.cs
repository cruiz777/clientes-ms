using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ParametrosFactura
{
    public long IdParametrosFactura { get; set; }

    public string Codpar { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Activado { get; set; }

    public double? Valor { get; set; }

    public string? Texto { get; set; }

    public DateTime? Fecmod { get; set; }

    public string? Obs { get; set; }
}
