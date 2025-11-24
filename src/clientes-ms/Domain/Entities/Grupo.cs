using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Grupo
{
    public long IdGrupo { get; set; }

    public long IdSeccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual Seccion IdSeccionNavigation { get; set; } = null!;

    public virtual ICollection<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; } = new List<ProductoEstructuraComercial>();
}
