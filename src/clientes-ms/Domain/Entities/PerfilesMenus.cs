using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PerfilesMenus
{
    public long IdPerfilMenu { get; set; }

    public long IdPerfil { get; set; }

    public long IdMenu { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Menus IdMenuNavigation { get; set; } = null!;

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;
}
