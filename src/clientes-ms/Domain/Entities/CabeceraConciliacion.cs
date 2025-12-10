using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraConciliacion
{
    public long IdConciliacion { get; set; }

    public string Fecconcil { get; set; } = null!;

    public string Cuenta { get; set; } = null!;

    public DateTime? Fechaconcil { get; set; }

    public string? Descripcta { get; set; }

    public double? Saldcontini { get; set; }

    public double? Saldcontfin { get; set; }

    public double? Saldbancini { get; set; }

    public double? Saldbancfin { get; set; }

    public double? Salconini { get; set; }

    public double? Salcondep { get; set; }

    public double? Salconchq { get; set; }

    public double? Salconnc { get; set; }

    public double? Salconnd { get; set; }

    public double? Salconbanc { get; set; }

    public double? Salcondif { get; set; }

    public double? Salconcidep { get; set; }

    public double? Salconcichq { get; set; }

    public double? Salconcinc { get; set; }

    public double? Salconcind { get; set; }

    public double? Salconcini { get; set; }

    public double? Salconcdep { get; set; }

    public double? Salconcchq { get; set; }

    public double? Salconcnc { get; set; }

    public double? Salconcnd { get; set; }

    public double? Salconcbanc { get; set; }

    public double? Salconcdif { get; set; }

    public long? IdEmpresa { get; set; }
}
