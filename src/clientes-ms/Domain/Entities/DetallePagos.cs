using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetallePagos
{
    public long IdDetallePago { get; set; }

    public string NumeroPago { get; set; } = null!;

    public string FormaPago { get; set; } = null!;

    public string Secuencia { get; set; } = null!;

    public string? DescripcionPago { get; set; }

    public double? Monto { get; set; }

    public double? AuxiliarContable { get; set; }

    public string? FacturaProveedor { get; set; }

    public string? Autorizacion { get; set; }

    public string? FechaAutorizacion { get; set; }

    public string? Banco { get; set; }

    public string? NumeroCuenta { get; set; }

    public string? Propietario { get; set; }

    public long? IdPago { get; set; }

    public string? Observaciones { get; set; }

    public string? LoteRecapitulacion { get; set; }

    public string? NumeroDocumento { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public virtual Pagos? IdPagoNavigation { get; set; }
}
