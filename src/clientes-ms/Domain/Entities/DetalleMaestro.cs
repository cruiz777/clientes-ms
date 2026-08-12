using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleMaestro
{
    public long IdDetMaestro { get; set; }

    public long IdCabMaestro { get; set; }

    public short Numlinea { get; set; }

    public string Anio { get; set; } = null!;

    public DateTime Fechatransaccion { get; set; }

    public string Hora { get; set; } = null!;

    public long IdZona { get; set; }

    public long? IdCentroCostos { get; set; }

    public int IdLocal { get; set; }

    public long IdPlanCuentas { get; set; }

    public string? CodprePc { get; set; }

    public long IdCodContable { get; set; }

    public string? Nocomprobante { get; set; }

    public string? Docurelacionado { get; set; }

    public double? Cheque { get; set; }

    public string? Beneficiario { get; set; }

    public double? Debe { get; set; }

    public double? Haber { get; set; }

    public string? Comentario { get; set; }

    public long? IdMovBancario { get; set; }

    public string? Movbancario { get; set; }

    public DateTime Fechaingreso { get; set; }

    public string? Cierre { get; set; }

    public DateTime? Fechacierre { get; set; }

    public string? Conciliado { get; set; }

    public DateTime? Fechaconciliado { get; set; }

    public long? IdSustentoTrib { get; set; }

    public long? IdTipoCompSri { get; set; }

    public string? Autorizacion { get; set; }

    public DateTime? Fechacaduca { get; set; }

    public long? IdTipoRetencion { get; set; }

    public long? IdProyecto { get; set; }

    public long? IdSubproyecto { get; set; }

    public bool Transferido { get; set; }

    public DateTime? Fechatransferido { get; set; }

    public DateTime? Fechavencimiento { get; set; }

    public long? IdConciliacion { get; set; }

    public string? ValorLetras { get; set; }

    public bool EstadoIngreso { get; set; }

    public string? AutorizacionRelacionado { get; set; }

    public DateTime? FechaCadRelacionado { get; set; }

    public long? IdPorIva { get; set; }

    public long? Porcentaje { get; set; }

    public virtual DetalleConciliacion? DetalleConciliacion { get; set; }

    public virtual CabeceraMaestro IdCabMaestroNavigation { get; set; } = null!;

    public virtual CentroCostos? IdCentroCostosNavigation { get; set; }

    public virtual CodigosContables IdCodContableNavigation { get; set; } = null!;

    public virtual Locales IdLocalNavigation { get; set; } = null!;

    public virtual MovimientoBancario? IdMovBancarioNavigation { get; set; }

    public virtual PlanCuentas IdPlanCuentasNavigation { get; set; } = null!;

    public virtual PorcentajeIva? IdPorIvaNavigation { get; set; }

    public virtual Proyectos? IdProyectoNavigation { get; set; }

    public virtual SustentoTributario? IdSustentoTribNavigation { get; set; }

    public virtual TipoComprobanteSri? IdTipoCompSriNavigation { get; set; }

    public virtual TipoRetencion? IdTipoRetencionNavigation { get; set; }
}
