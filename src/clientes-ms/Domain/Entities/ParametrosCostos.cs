using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ParametrosCostos
{
    public int IdParCosto { get; set; }

    public string? Nombre { get; set; }

    public string? ValorInicial { get; set; }

    public string? ValorFinal { get; set; }

    public string? Descripcion { get; set; }
}
