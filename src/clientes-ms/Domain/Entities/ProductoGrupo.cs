using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoGrupo
{
    public double Codgru { get; set; }

    public long IdEmpresa { get; set; }

    public string? Desgru { get; set; }

    public string? Sec { get; set; }

    public bool? Estado { get; set; }
}
