using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpFormacion
{
    public long IdEmpleado { get; set; }

    public string? Institucion { get; set; }

    public string? Observacion { get; set; }

    public string? Titulo { get; set; }

    public long? IdNivelInstruccion { get; set; }

    public DateOnly? FechaDesde { get; set; }

    public DateOnly? FechaHasta { get; set; }

    public long IdFormacion { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual RpNivelInstruccion? IdNivelInstruccionNavigation { get; set; }
}
