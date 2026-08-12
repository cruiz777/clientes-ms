using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class VwFacturasMantenimientoPorAnio
{
    public long? ClienteCodigo { get; set; }

    public string? Ruc { get; set; }

    public int? Anio { get; set; }

    public string? Prefijo { get; set; }

    public int? FacBloque { get; set; }

    public string? Origen { get; set; }

    public string? NumNota { get; set; }

    public DateOnly? FechaNota { get; set; }
}
