using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FacturaDetalle
{
    public long IdFacturaDet { get; set; }

    public string Numnota { get; set; } = null!;

    public double Tipdoc { get; set; }

    public short Id { get; set; }

    public string? Codloc { get; set; }

    public string? Cantid { get; set; }

    public decimal? Precio { get; set; }

    public string? Costo { get; set; }

    public string? Desind { get; set; }

    public string? Uniman { get; set; }

    public double? Coddiv { get; set; }

    public double? Coddep { get; set; }

    public double? Codsec { get; set; }

    public string? Caja { get; set; }

    public string? Iva { get; set; }

    public double? Candev { get; set; }

    public string? Encero { get; set; }

    public string? Codbar { get; set; }

    public string? Obs2 { get; set; }

    public long? IdProducto { get; set; }

    public long? IdDescuento { get; set; }

    public virtual Descuento? IdDescuentoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Nota NumnotaNavigation { get; set; } = null!;
}
