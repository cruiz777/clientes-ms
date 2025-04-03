using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Zona
{
    public long IdZona { get; set; }

    public string? Referencia { get; set; }

    public string? Nombre { get; set; }

    public string? Numero { get; set; }

    public long? EmpresaCodigo { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }
}
