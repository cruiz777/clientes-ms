using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Genero
{
    public long GeneroCodigo { get; set; }

    public string? GeneroDescripcion { get; set; }

    public string? GeneroReferencia { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();
}
