using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Division
{
    public long IdDivision { get; set; }

    public long IdEstructuraComercial { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual EstructuraComercial IdEstructuraComercialNavigation { get; set; } = null!;

    public virtual ICollection<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; } = new List<ProductoEstructuraComercial>();

    public virtual ICollection<SubDivision> SubDivision { get; set; } = new List<SubDivision>();
}
