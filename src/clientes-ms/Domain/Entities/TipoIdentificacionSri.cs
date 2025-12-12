using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoIdentificacionSri
{
    public int IdTipIdSri { get; set; }

    public string Nombre { get; set; } = null!;

    public string CodigoSri { get; set; } = null!;
}
