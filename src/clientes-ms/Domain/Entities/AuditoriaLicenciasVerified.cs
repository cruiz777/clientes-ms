using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AuditoriaLicenciasVerified
{
    public long IdAuditoria { get; set; }

    public string LicenceKey { get; set; } = null!;

    public string? LicenceType { get; set; }

    public int? ClientesCodigo { get; set; }

    public string? LicenseeName { get; set; }

    public string? LicenseeGln { get; set; }

    public string? EstadoAnterior { get; set; }

    public string EstadoNuevo { get; set; } = null!;

    public int? IdEstadoEmpresaAntes { get; set; }

    public int? IdEstadoEmpresaNuevo { get; set; }

    public int? Gs1HttpStatus { get; set; }

    public string? Gs1Status { get; set; }

    public string? Gs1RequestId { get; set; }

    public string? Gs1Response { get; set; }

    public bool ActualizacionLocalOk { get; set; }

    public string? Usuario { get; set; }

    public DateTime Fecha { get; set; }

    public string? Error { get; set; }
}
