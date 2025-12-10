using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoSeccion
{
    public long IdProdSeccion { get; set; }

    public long IdEmpresa { get; set; }

    public string? DescripcionSeccion { get; set; }

    public long? IdProdDepartamento { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<ProductoGrupo> ProductoGrupo { get; set; } = new List<ProductoGrupo>();
}
