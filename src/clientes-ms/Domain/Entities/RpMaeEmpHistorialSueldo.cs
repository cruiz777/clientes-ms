using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpHistorialSueldo
{
    public long IdHistorialSueldo { get; set; }

    public long IdEmpleado { get; set; }

    public DateOnly? FechaSueldo { get; set; }

    public double? Sueldo { get; set; }

    public double? ValorHora { get; set; }

    public double? ValorHoraEspe { get; set; }

    public bool? Valhorain { get; set; }

    public double? Quincena { get; set; }

    public double? QuincenaIi { get; set; }
}
