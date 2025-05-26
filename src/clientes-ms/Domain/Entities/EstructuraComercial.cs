using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class EstructuraComercial
{
    public string Codest { get; set; } = null!;

    public long IdEmpresa { get; set; }

    public string? Descri { get; set; }

    public double? Numnodos { get; set; }

    public bool? Estado { get; set; }
}
