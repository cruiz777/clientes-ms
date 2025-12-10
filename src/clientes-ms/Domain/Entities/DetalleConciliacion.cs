using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleConciliacion
{
    public long IdDetConciliacion { get; set; }

    public long IdConciliacion { get; set; }

    public string Fecconcil { get; set; } = null!;

    public string Cuenta { get; set; } = null!;

    public double Linea { get; set; }

    public DateTime? Fechatran { get; set; }

    public string? Tipmov { get; set; }

    public string? Numcomp { get; set; }

    public string? Cheque { get; set; }

    public double? Debito { get; set; }

    public double? Credito { get; set; }

    public string? Concil { get; set; }

    public DateTime? Fechaconcil { get; set; }

    public string? Numdoc { get; set; }

    public string? Beneficiario { get; set; }

    public string? Tipdoc { get; set; }
}
