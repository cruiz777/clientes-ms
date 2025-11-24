using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Departamento
{
    public long IdDepartamento { get; set; }

    public long IdSubDivision { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual SubDivision IdSubDivisionNavigation { get; set; } = null!;

    public virtual ICollection<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; } = new List<ProductoEstructuraComercial>();

    public virtual ICollection<Seccion> Seccion { get; set; } = new List<Seccion>();
}
