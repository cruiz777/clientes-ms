using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDivision
{
    public long IdCodigoDivision { get; set; }

    public string? DescripcionDivision { get; set; }

    public long? IdEstructuraComercial { get; set; }

    public long? IdEmpresa { get; set; }

    public bool? Estado { get; set; }

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual EstructuraComercial? IdEstructuraComercialNavigation { get; set; }

    public virtual ICollection<ProductoSubDivision> ProductoSubDivision { get; set; } = new List<ProductoSubDivision>();
}
