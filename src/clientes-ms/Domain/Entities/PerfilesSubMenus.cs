using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PerfilesSubMenus
{
    public long IdPerfilSubMenu { get; set; }

    public long IdPerfil { get; set; }

    public long IdSub { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool Status { get; set; }

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;

    public virtual SubMenus IdSubNavigation { get; set; } = null!;
}
