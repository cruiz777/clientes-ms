using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class EstadoCuentas
{
    public long Id { get; set; }

    public string Numfac { get; set; } = null!;

    public string Tipodoc { get; set; } = null!;

    public string TipDoc { get; set; } = null!;

    public string Numdoc { get; set; } = null!;

    public long ClienteCodigo { get; set; }

    public string Fecha { get; set; } = null!;

    public double? Debe { get; set; }

    public double? Haber { get; set; }

    public string? Observacion { get; set; }

    public string? FormaPago { get; set; }

    public string? ClasPago { get; set; }

    public string? Caja { get; set; }

    public long? Responsable { get; set; }

    public string? HistoriaClinica { get; set; }

    public string? AteCodigo { get; set; }

    public bool? PagoAnulado { get; set; }
}
