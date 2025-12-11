using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class BancosEmpresa
{
    public long IdBancosEmpresa { get; set; }

    public string? CtaCble { get; set; }

    public string? Descripcio { get; set; }

    public string? CtaCorriente { get; set; }

    public long IdBanco { get; set; }

    public long IdEmpresa { get; set; }
}
