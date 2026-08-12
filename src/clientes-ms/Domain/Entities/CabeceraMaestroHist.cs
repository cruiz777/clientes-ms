using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraMaestroHist
{
    public long AuditId { get; set; }

    public Guid BatchId { get; set; }

    public DateTime AuditAt { get; set; }

    public long? AuditUserId { get; set; }

    public string AuditAction { get; set; } = null!;

    public long OriginalIdCabMaestro { get; set; }

    public long IdZona { get; set; }

    public long IdUsuario { get; set; }

    public long IdEmpresa { get; set; }

    public long IdTipoAsiento { get; set; }

    public string Tipdoc { get; set; } = null!;

    public double Numdoc { get; set; }

    public string Anio { get; set; } = null!;

    public DateTime Fechatransaccion { get; set; }

    public DateTime Fechaingreso { get; set; }

    public string? Observacion { get; set; }

    public double? Totdebe { get; set; }

    public double? Tothaber { get; set; }

    public string? Beneficiario { get; set; }

    public string? Cierre { get; set; }

    public DateTime? Fechacierre { get; set; }

    public string? Solicitado { get; set; }

    public string? Depto { get; set; }

    public string? Autorizado { get; set; }

    public long HomCodigo { get; set; }

    public bool Estado { get; set; }

    public int Modulo { get; set; }
}
