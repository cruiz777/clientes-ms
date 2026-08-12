using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpCronologia
{
    public long IdCronologia { get; set; }

    public long IdEmpleado { get; set; }

    public int NroContrato { get; set; }

    public long? IdTipoContrato { get; set; }

    public DateOnly? FecIngreso { get; set; }

    public DateOnly? FecSalida { get; set; }

    public DateOnly? FecTercont { get; set; }

    public int? NumContrato { get; set; }

    public double? HorasContrato { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual RpTipoContrato? IdTipoContratoNavigation { get; set; }
}
