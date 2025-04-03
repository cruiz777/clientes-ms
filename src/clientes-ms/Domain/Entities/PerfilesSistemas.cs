using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PerfilesSistemas
{
    public long IdPerfilSistema { get; set; }

    public long IdPerfil { get; set; }

    public long IdSistema { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;

    public virtual Sistemas IdSistemaNavigation { get; set; } = null!;
}
