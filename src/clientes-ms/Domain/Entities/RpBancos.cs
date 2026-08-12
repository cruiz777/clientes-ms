using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpBancos
{
    public long Codban { get; set; }

    public string Desban { get; set; } = null!;

    public string? Codcue { get; set; }

    public string? Ctacontabilidad { get; set; }

    public string? Desban2 { get; set; }

    public string? CodigoEspeacial { get; set; }

    public virtual ICollection<NominaEspecial> NominaEspecial { get; set; } = new List<NominaEspecial>();

    public virtual ICollection<RpMaeEmpHistorialBanco> RpMaeEmpHistorialBanco { get; set; } = new List<RpMaeEmpHistorialBanco>();
}
