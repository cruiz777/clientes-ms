using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class EstadoCivil
{
    public long EstadoCivilCodigo { get; set; }

    public string? EstadoCivilNombre { get; set; }

    public string? EstadoCivilReferencia { get; set; }

    public virtual ICollection<Personas> Personas { get; set; } = new List<Personas>();
}
