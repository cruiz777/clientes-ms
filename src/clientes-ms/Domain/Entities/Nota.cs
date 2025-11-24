using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Nota
{
    public long IdNota { get; set; }

    public long IdCliente { get; set; }

    public long IdGrupoEmpresa { get; set; }

    public long IdEmpresa { get; set; }

    public long? IdTipoCliente { get; set; }

    public string Numnota { get; set; } = null!;

    public double Tipdoc { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Hora { get; set; }

    public string? Ruc { get; set; }

    public double? Subtotal { get; set; }

    public double? Desctot { get; set; }

    public double? Totsiva { get; set; }

    public double? Totciva { get; set; }

    public double? Total { get; set; }

    public string? Fecha1 { get; set; }

    public string? Cancelado { get; set; }

    public double? Items { get; set; }

    public string? Nomcli { get; set; }

    public string? Dircli { get; set; }

    public string? Telcli { get; set; }

    public string? Ruccli { get; set; }

    public string? Obs { get; set; }

    public string? Numguirem { get; set; }

    public string? Motivo { get; set; }

    public DateTime? Fecven { get; set; }

    public string? Numorden { get; set; }

    public string? Tiempoentrega { get; set; }

    public long? IdAutorizacionCaja { get; set; }

    public double? SubtDev { get; set; }

    public double? ConivaDev { get; set; }

    public double? SinivaDev { get; set; }

    public double? DesctDev { get; set; }

    public double? IvaDev { get; set; }

    public double? TotDev { get; set; }

    public bool Pormayor { get; set; }

    public bool Facturada { get; set; }

    public bool Coniva { get; set; }

    public bool? ImprimeDesct { get; set; }

    public string? Autorizacion { get; set; }

    public string? GrupoCliente { get; set; }

    public int? ConvId { get; set; }

    public string? Prefijo { get; set; }

    public double PorfectajeIva { get; set; }

    public string? AsientoContable { get; set; }

    public int FacBloque { get; set; }

    public string? ClaveAcceso { get; set; }

    public double AnioFactura { get; set; }

    public long IdDescuento { get; set; }

    public long? IdLocal { get; set; }

    public double? Iva { get; set; }

    public long? Cajero { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();

    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();

    public virtual AutorizacionCaja? IdAutorizacionCajaNavigation { get; set; }

    public virtual Clientes IdClienteNavigation { get; set; } = null!;

    public virtual Descuento IdDescuentoNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;
}
