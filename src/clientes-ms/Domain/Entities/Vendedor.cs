using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Vendedor
{
    public long IdVendedor { get; set; }

    public string? Nombre { get; set; }

    public string? Ruc { get; set; }

    public string? PorVendedor { get; set; }

    public DateOnly? Fecing { get; set; }

    public DateOnly? Fecsal { get; set; }

    public short? Estado { get; set; }

    public long? EmpresaCodigo { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }
}
