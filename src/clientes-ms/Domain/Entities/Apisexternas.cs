using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Apisexternas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Urlbase { get; set; } = null!;

    public string Ruta { get; set; } = null!;

    public string? ApiKey { get; set; }

    public bool Estado { get; set; }
}
