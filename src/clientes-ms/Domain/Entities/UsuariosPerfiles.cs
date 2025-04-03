using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class UsuariosPerfiles
{
    public long IdUsuarioPerfiles { get; set; }

    public long IdUsuario { get; set; }

    public long IdPerfil { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
