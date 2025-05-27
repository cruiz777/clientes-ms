using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoDepartamento
{
    public long IdProdDepartamento { get; set; }

    public long IdEmpresa { get; set; }

    public string? DescripcionProdDepartamento { get; set; }

    public long? IdSubdivision { get; set; }

    public bool? Estado { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ProductoSubDivision? IdSubdivisionNavigation { get; set; }

    public virtual ICollection<ProductoSeccion> ProductoSeccion { get; set; } = new List<ProductoSeccion>();
}
