using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DatosAdicionales
{
    public long IdDatosAdicionales { get; set; }

    public int? Expprod { get; set; }

    public int? Vendeus { get; set; }

    public int? Medico { get; set; }

    public int? Gs1ec { get; set; }

    public int? Instagram { get; set; }

    public int? Facebook { get; set; }

    public string? Web { get; set; }

    public long? ClientesCodigo { get; set; }
}
