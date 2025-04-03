using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class UsuariosRoles
{
    public long IdUsuario { get; set; }

    public int IdRol { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Roles IdRolNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
