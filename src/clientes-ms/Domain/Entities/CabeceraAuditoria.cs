using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraAuditoria
{
    public double? Codrespon { get; set; }

    public double? Codzona { get; set; }

    public string Tipdoc { get; set; } = null!;

    public double Numdoc { get; set; }

    public DateTime Hora { get; set; }

    public DateTime Fechatran { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Fechaing { get; set; }

    public double? Totdebe { get; set; }

    public double? Tothaber { get; set; }

    public double? Fecha1 { get; set; }

    public double? Fecha2 { get; set; }

    public double? Fecha3 { get; set; }

    public string? Beneficiario { get; set; }

    public double? Cotizacion { get; set; }

    public double? Vdolares { get; set; }

    public string? Observacion { get; set; }

    public bool Marca { get; set; }

    public double? Codusuario { get; set; }

    public string? Solicitado { get; set; }

    public string? Depto { get; set; }

    public string? Autorizado { get; set; }

    public long HomCodigo { get; set; }

    public string? DescAnulacion { get; set; }

    public int EstadoAnula { get; set; }

    public long IdCabecera { get; set; }
}
