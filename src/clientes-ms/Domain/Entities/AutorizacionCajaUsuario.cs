using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AutorizacionCajaUsuario
{
    public long IdAutorizacionUsuario { get; set; }

    public long IdUsuario { get; set; }

    public long IdAutorizacionCaja { get; set; }

    public bool? Activa { get; set; }

    public virtual AutorizacionCaja IdAutorizacionCajaNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
