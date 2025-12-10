using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoMovimiento
{
    public string IdTipoMov { get; set; } = null!;

    public string? TipoMov { get; set; }

    public string? Calculo { get; set; }

    public string? CodigoCuenta { get; set; }

    public bool Activo { get; set; }
}
