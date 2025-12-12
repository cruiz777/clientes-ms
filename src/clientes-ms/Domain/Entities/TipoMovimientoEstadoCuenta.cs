using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoMovimientoEstadoCuenta
{
    public int IdTipDoc { get; set; }

    public string CodigoTipDoc { get; set; } = null!;

    public string DescripcionTipDoc { get; set; } = null!;
}
