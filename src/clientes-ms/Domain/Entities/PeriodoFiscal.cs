using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PeriodoFiscal
{
    public long IdPeriodoFiscal { get; set; }

    public string? Descripcion { get; set; }

    public int? Anio { get; set; }

    public DateOnly? FechaInicial { get; set; }

    public DateOnly? FechaFinal { get; set; }

    public string? EstadoPeriodo { get; set; }

    public string? Estado { get; set; }

    public long? IdEmpresa { get; set; }
}
