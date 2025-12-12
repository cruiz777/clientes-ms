using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ParametrosCg
{
    public long Codparamt { get; set; }

    public string? Desparamt { get; set; }

    public string? Descripcion { get; set; }

    public string? Codigo { get; set; }

    public long? IdEmpresa { get; set; }
}
