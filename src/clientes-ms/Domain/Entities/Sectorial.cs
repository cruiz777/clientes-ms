using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Sectorial
{
    public long IdSectorial { get; set; }

    public string? EstructuraOcupacional { get; set; }

    public string DesSectorial { get; set; } = null!;

    public string? CodigoIess { get; set; }

    public decimal? SalarioMinimo { get; set; }

    public decimal? TarifaMinima { get; set; }

    public bool Estado { get; set; }

    public long IdEmpresa { get; set; }

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
