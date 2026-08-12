using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpTipoContrato
{
    public long IdTipoContrato { get; set; }

    public string Descripcion { get; set; } = null!;

    public double? Valor { get; set; }

    public string? Estado { get; set; }

    public double? Paramhoras { get; set; }

    public string? Grupotipo { get; set; }

    public decimal? Horassemana { get; set; }

    public bool Bono { get; set; }

    public string? Codigo { get; set; }

    public virtual ICollection<RpMaeEmpCronologia> RpMaeEmpCronologia { get; set; } = new List<RpMaeEmpCronologia>();
}
