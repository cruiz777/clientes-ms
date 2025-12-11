using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class EstructuraComercial
{
    public long IdEstructuraComercial { get; set; }

    public long IdEmpresa { get; set; }

    public string? Descri { get; set; }

    public double? Numnodos { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Division> Division { get; set; } = new List<Division>();

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;
}
