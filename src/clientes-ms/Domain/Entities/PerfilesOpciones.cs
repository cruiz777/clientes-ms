using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PerfilesOpciones
{
    public long IdPerfilOpcion { get; set; }

    public long IdPerfil { get; set; }

    public long IdOpcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool Status { get; set; }

    public virtual Opciones IdOpcionNavigation { get; set; } = null!;

    public virtual Perfiles IdPerfilNavigation { get; set; } = null!;
}
