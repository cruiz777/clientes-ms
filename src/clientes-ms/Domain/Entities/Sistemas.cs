using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Sistemas
{
    public long IdSistema { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Modulos> Modulos { get; set; } = new List<Modulos>();

    public virtual ICollection<PerfilesSistemas> PerfilesSistemas { get; set; } = new List<PerfilesSistemas>();
}
