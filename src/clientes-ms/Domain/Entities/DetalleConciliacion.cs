using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleConciliacion
{
    public long IdDetConciliacion { get; set; }

    public long IdConciliacion { get; set; }

    public long IdDetMaestro { get; set; }

    public short Linea { get; set; }

    public DateTime? Fechatran { get; set; }

    public long? IdMovBancario { get; set; }

    public string? Movbancario { get; set; }

    public string? Nocomprobante { get; set; }

    public double? Cheque { get; set; }

    public double? Debito { get; set; }

    public double? Credito { get; set; }

    public string? Concil { get; set; }

    public DateTime? Fechaconcil { get; set; }

    public string? Beneficiario { get; set; }

    public string? Numdoc { get; set; }

    public string? Tipdoc { get; set; }

    public virtual CabeceraConciliacion IdConciliacionNavigation { get; set; } = null!;

    public virtual DetalleMaestro IdDetMaestroNavigation { get; set; } = null!;

    public virtual MovimientoBancario? IdMovBancarioNavigation { get; set; }
}
