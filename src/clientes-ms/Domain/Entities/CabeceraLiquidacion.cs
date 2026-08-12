using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraLiquidacion
{
    public long IdCabLiquidacion { get; set; }

    public string Numliquida { get; set; } = null!;

    public string Caja { get; set; } = null!;

    public long IdCodContable { get; set; }

    public string? Ruc { get; set; }

    public DateOnly Fecha { get; set; }

    public DateTime Fechaing { get; set; }

    public string? Observacion { get; set; }

    public double Subtotal { get; set; }

    public double Coniva { get; set; }

    public double Siniva { get; set; }

    public double Iva { get; set; }

    public double Total { get; set; }

    public string? Autorizacion { get; set; }

    public DateOnly? Fechacad { get; set; }

    public long IdEmpresa { get; set; }

    public long IdUsuario { get; set; }

    public long IdCabMaestro { get; set; }

    public string? Numdoc { get; set; }

    public string Tipdoc { get; set; } = null!;

    public long? IdTipoCompSri { get; set; }

    public bool Enviado { get; set; }

    public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; } = new List<DetalleLiquidacion>();

    public virtual ICollection<FormaPagoLiquidacion> FormaPagoLiquidacion { get; set; } = new List<FormaPagoLiquidacion>();

    public virtual CabeceraMaestro IdCabMaestroNavigation { get; set; } = null!;

    public virtual CodigosContables IdCodContableNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual TipoComprobanteSri? IdTipoCompSriNavigation { get; set; }

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
