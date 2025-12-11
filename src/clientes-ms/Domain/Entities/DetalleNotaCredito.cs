using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DetalleNotaCredito
{
    public long IdDetNotaCredito { get; set; }

    public long? IdNotaCredito { get; set; }

    public string Codpro { get; set; } = null!;

    public int? Fila { get; set; }

    public double Cantidad { get; set; }

    public double Costo { get; set; }

    public double Precio { get; set; }

    public double Iva { get; set; }

    public string Estado { get; set; } = null!;

    public double CantidadAnterior { get; set; }

    public double Descuento { get; set; }

    public string? TipoIva { get; set; }

    public long CueCodigo { get; set; }

    public string? Descripcion { get; set; }

    public virtual NotaCredito? IdNotaCreditoNavigation { get; set; }
}
