using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoCliente
{
    public long IdTipoCliente { get; set; }

    public string? Descripcion { get; set; }

    public string? Cuenta { get; set; }

    public long? EmpresaCodigo { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }
}
