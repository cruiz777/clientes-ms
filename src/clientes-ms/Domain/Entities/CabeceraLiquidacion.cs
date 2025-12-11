using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraLiquidacion
{
    public long IdCabLiquidacion { get; set; }

    public string Numliquida { get; set; } = null!;

    public string Caja { get; set; } = null!;

    public double CodigoC { get; set; }

    public string? Ruc { get; set; }

    public DateOnly? Fecha { get; set; }

    public DateOnly? Fechaing { get; set; }

    public string? Observacion { get; set; }

    public double Subtotal { get; set; }

    public double Coniva { get; set; }

    public double Siniva { get; set; }

    public double Iva { get; set; }

    public double Total { get; set; }

    public string? Autorizacion { get; set; }

    public DateOnly? Fechacad { get; set; }

    public string? Tipdoc { get; set; }

    public string? Numdoc { get; set; }

    public long? IdEmpresa { get; set; }
}
