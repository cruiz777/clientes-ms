using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class SubDivision
{
    public long IdSubDivision { get; set; }

    public long IdDivision { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Departamento> Departamento { get; set; } = new List<Departamento>();

    public virtual Division IdDivisionNavigation { get; set; } = null!;

    public virtual ICollection<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; } = new List<ProductoEstructuraComercial>();
}
