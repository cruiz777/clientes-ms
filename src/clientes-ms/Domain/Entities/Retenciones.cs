using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Retenciones
{
    public long IdRetencion { get; set; }

    public long IdEmpresa { get; set; }

    public long IdCabMaestro { get; set; }

    public string Numdoc { get; set; } = null!;

    public short Numlinea { get; set; }

    public string Anio { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Hora { get; set; } = null!;

    public string TipoComp { get; set; } = null!;

    public string? DesComp { get; set; }

    public long IdCodContable { get; set; }

    public string? Contribuyente { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? RucCi { get; set; }

    public long? IdTipoCompSri { get; set; }

    public string? TipoComprobante { get; set; }

    public string? TipCompVta { get; set; }

    public string? NumCompVta { get; set; }

    public string? EjerFiscal { get; set; }

    public double? BaseImponible { get; set; }

    public double? PorcentajeRetencion { get; set; }

    public double? ValorRetenido { get; set; }

    public string? Concepto { get; set; }

    public long IdTipoRetencion { get; set; }

    public string? CodigoRetencion { get; set; }

    public DateTime FechaIng { get; set; }

    public string? AutRetencion { get; set; }

    public string? NumEstablecimiento { get; set; }

    public string? PuntoEmision { get; set; }

    public string? Secuencial { get; set; }

    public bool Enviado { get; set; }

    public string? TipoMovimiento { get; set; }

    public bool EstadoIngreso { get; set; }

    public long IdUsuario { get; set; }

    public virtual CabeceraMaestro IdCabMaestroNavigation { get; set; } = null!;

    public virtual CodigosContables IdCodContableNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual TipoComprobanteSri? IdTipoCompSriNavigation { get; set; }

    public virtual TipoRetencion IdTipoRetencionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
