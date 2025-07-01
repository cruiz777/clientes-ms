using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Parametros
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Tipo { get; set; } = null!;

    public bool? Requerido { get; set; }

    public bool? Multiple { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<ParametrosDetalle> ParametrosDetalle { get; set; } = new List<ParametrosDetalle>();
}
