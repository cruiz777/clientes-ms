using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Pagos
{
    public long IdPago { get; set; }

    public string NumeroPago { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public long ClienteCodigo { get; set; }

    public DateTime Fecha { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public double? TotalPago { get; set; }

    public string? Observaciones { get; set; }

    public string? Pagado { get; set; }

    public bool TieneRetencionIva { get; set; }

    public string? ValorRetencionIva { get; set; }

    public bool TieneRetencionFuente { get; set; }

    public string? ValorRetencionFuente { get; set; }

    public string? PagosTexto { get; set; }

    public string? FechaSecundaria { get; set; }

    public double? CodigoResponsable { get; set; }

    public string? Consecutivo { get; set; }

    public string? Caja { get; set; }

    public string? FormaPagoPrincipal { get; set; }

    public long? NumeroLiquidacion { get; set; }

    public string? AsientoContable { get; set; }

    public string? Comentario { get; set; }

    public double? FilaCuentasPorCobrar { get; set; }

    public bool? Arqueada { get; set; }

    public bool PagoAnulado { get; set; }

    public string? FechaAnulacion { get; set; }

    public virtual Clientes ClienteCodigoNavigation { get; set; } = null!;

    public virtual ICollection<DetallePagos> DetallePagos { get; set; } = new List<DetallePagos>();
}
