using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleAuditoria
{
    public string Tipdoc { get; set; } = null!;

    public double Numdoc { get; set; }

    public short Numlinea { get; set; }

    public DateTime Hora { get; set; }

    public DateTime Fechatran { get; set; }

    public double? Codzona { get; set; }

    public double? Codloc { get; set; }

    public string? CodcueCp { get; set; }

    public string? CuentaPc { get; set; }

    public string? SubctaPc { get; set; }

    public string? CodprePc { get; set; }

    public double? CodigoC { get; set; }

    public string? Nocomp { get; set; }

    public string? Nundocum { get; set; }

    public double? Cheque { get; set; }

    public string? Beneficiario { get; set; }

    public double? Debe { get; set; }

    public double? Haber { get; set; }

    public string? Comentario { get; set; }

    public string? Movbanc { get; set; }

    public DateTime? Fechaing { get; set; }

    public DateTime? Fecha { get; set; }

    public double? Fecha1 { get; set; }

    public double? Fecha2 { get; set; }

    public double? Fecha3 { get; set; }

    public double? Cotizacion { get; set; }

    public double? Debedl { get; set; }

    public double? Haberdl { get; set; }

    public string? Conciliado { get; set; }

    public DateTime? Fecconcil { get; set; }

    public string? Sustentotrib { get; set; }

    public string? Tipcomprob { get; set; }

    public string? Autorizacion { get; set; }

    public string? Feccaduca { get; set; }

    public string? Codretfuente { get; set; }

    public int? Codcentrocosto { get; set; }

    public int? Codrubro { get; set; }

    public int? Codactividad { get; set; }

    public bool Marca { get; set; }

    public string? Estado { get; set; }

    public double? SaldoxP { get; set; }

    public double? VPagado { get; set; }

    public DateTime? Fecvenc { get; set; }

    public bool Transferido { get; set; }

    public DateTime? Fechatransf { get; set; }

    public DateTime? Fechadocumento { get; set; }

    public long IdDetalle { get; set; }

    public long IdCabecera { get; set; }
}
