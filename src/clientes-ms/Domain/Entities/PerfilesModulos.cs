using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PerfilesModulos
{
    public long IdPerfilModulo { get; set; }

    public long IdPerfil { get; set; }

    public long IdModulo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool Status { get; set; }

    public virtual Modulos IdModuloNavigation { get; set; } = null!;

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;
}
