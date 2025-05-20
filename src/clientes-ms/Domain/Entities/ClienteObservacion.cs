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

    public string? NombreUsuario { get; set; }

    public int? Linea { get; set; }

    public virtual Clientes ClientesCodigoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
