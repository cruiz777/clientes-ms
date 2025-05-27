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

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<ProductoDivision> ProductoDivision { get; set; } = new List<ProductoDivision>();
}
