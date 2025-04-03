using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ClienteObservacion
{
    public long IdClienteObservacion { get; set; }

    public string? Detalle { get; set; }

    public DateTime? Fecha { get; set; }

    public long IdUsuario { get; set; }

    public long ClientesCodigo { get; set; }
}
