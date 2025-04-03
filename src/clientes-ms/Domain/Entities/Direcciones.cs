using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Direcciones
{
    public long IdDireccion { get; set; }

    public long IdPersona { get; set; }

    public string Tipo { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Pais { get; set; }

    public virtual Personas IdPersonaNavigation { get; set; } = null!;
}
