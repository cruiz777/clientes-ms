using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPago
{
    public long IdFormaPago { get; set; }

    public long IdClasificacion { get; set; }

    public long IdFormaPagoSri { get; set; }

    public string? DescripcionPago { get; set; }

    public string? CodigoCuenta { get; set; }

    public bool? ActivarFactura { get; set; }

    public bool ActivarCuentas { get; set; }

    public bool Cxc { get; set; }

    public bool? ActivarFacturaHis { get; set; }

    public bool ActivarLiqTarjeta { get; set; }

    public bool? ActivarPagParjeta { get; set; }

    public bool? ActivarAnticipo { get; set; }

    public string? Codigocg { get; set; }

    public string? Codigosic { get; set; }

    public long? IdEmpresa { get; set; }

    public long? IdPlanCuentas { get; set; }

    public virtual ICollection<Anticipo> Anticipo { get; set; } = new List<Anticipo>();

    public virtual ICollection<AnticipoLiquida> AnticipoLiquida { get; set; } = new List<AnticipoLiquida>();

    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();

    public virtual Clasificacion IdClasificacionNavigation { get; set; } = null!;

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual FormaPagoSri1 IdFormaPagoSriNavigation { get; set; } = null!;

    public virtual PlanCuentas? IdPlanCuentasNavigation { get; set; }
}
