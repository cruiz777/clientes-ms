using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Seccion
{
    public long IdSeccion { get; set; }

    public long IdDepartamento { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Grupo> Grupo { get; set; } = new List<Grupo>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; } = new List<ProductoEstructuraComercial>();
}
