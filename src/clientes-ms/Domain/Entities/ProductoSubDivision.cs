using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoSubDivision
{
    public long IdSubDivision { get; set; }

    public long IdEmpresa { get; set; }

    public string? DescripcionSubdivision { get; set; }

    public long? IdDivision { get; set; }

    public int? PeaCodigoHis { get; set; }

    public bool? Estado { get; set; }

    public virtual ProductoDivision? IdDivisionNavigation { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<ProductoDepartamento> ProductoDepartamento { get; set; } = new List<ProductoDepartamento>();
}
