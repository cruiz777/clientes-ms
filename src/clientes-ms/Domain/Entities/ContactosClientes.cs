using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ContactosClientes
{
    public long IdContaactos { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public long? ClientesCodigo { get; set; }

    public string? Cargo { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }
}
