using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoEstructuraComercial
{
    public long IdProducto { get; set; }

    public long? IdDivision { get; set; }

    public long? IdSubDivision { get; set; }

    public long? IdDepartamento { get; set; }

    public long? IdSeccion { get; set; }

    public long? IdGrupo { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Division? IdDivisionNavigation { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Seccion? IdSeccionNavigation { get; set; }

    public virtual SubDivision? IdSubDivisionNavigation { get; set; }
}
