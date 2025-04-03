using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Modulos
{
    public long IdModulo { get; set; }

    public long IdSistema { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Status { get; set; }

    public virtual Sistemas IdSistemaNavigation { get; set; } = null!;

    public virtual ICollection<Menus> Menus { get; set; } = new List<Menus>();

    public virtual ICollection<PerfilesModulos> PerfilesModulos { get; set; } = new List<PerfilesModulos>();
}
