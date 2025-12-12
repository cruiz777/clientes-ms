using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class SubMenus
{
    public long IdSub { get; set; }

    public long IdMenu { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Status { get; set; }

    public string? Url { get; set; }

    public virtual Menus IdMenuNavigation { get; set; } = null!;

    public virtual ICollection<Opciones> Opciones { get; set; } = new List<Opciones>();

    public virtual ICollection<PerfilesSubMenus> PerfilesSubMenus { get; set; } = new List<PerfilesSubMenus>();
}
