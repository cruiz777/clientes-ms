using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Correos
{
    public long IdCorreo { get; set; }

    public long IdPersona { get; set; }

    public string Tipo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? EsPrincipal { get; set; }

    public virtual Personas IdPersonaNavigation { get; set; } = null!;
}
