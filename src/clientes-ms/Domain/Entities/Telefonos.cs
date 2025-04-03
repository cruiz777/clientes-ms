using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Telefonos
{
    public int IdTelefono { get; set; }

    public long IdPersona { get; set; }

    public string Tipo { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public bool? EsPrincipal { get; set; }

    public virtual Personas IdPersonaNavigation { get; set; } = null!;
}
