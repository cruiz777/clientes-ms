using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Opciones
{
    public long IdOpcion { get; set; }

    public long IdSub { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Status { get; set; }

    public virtual SubMenus IdSubNavigation { get; set; } = null!;

    public virtual ICollection<PerfilesOpciones> PerfilesOpciones { get; set; } = new List<PerfilesOpciones>();
}
