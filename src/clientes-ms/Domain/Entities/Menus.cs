using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Menus
{
    public long IdMenu { get; set; }

    public long IdModulo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Status { get; set; }

    public virtual Modulos IdModuloNavigation { get; set; } = null!;

    public virtual ICollection<Opciones> Opciones { get; set; } = new List<Opciones>();

    public virtual ICollection<PerfilesMenus> PerfilesMenus { get; set; } = new List<PerfilesMenus>();
}
