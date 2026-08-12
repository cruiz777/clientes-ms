using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Observaciones
{
    public int IdObs { get; set; }

    public long IdEmpresa { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Detalle { get; set; }

    public string? UnidadTiempo { get; set; }

    public string? Tiempo { get; set; }

    public bool? IncluirNomina { get; set; }

    public int IdTipoObservacion { get; set; }

    public int? IdDoc { get; set; }

    public int? IdTipoVacacion { get; set; }

    public bool? Estado { get; set; }

    public long? IdEmpleado { get; set; }

    public virtual RpMaeEmp? IdEmpleadoNavigation { get; set; }

    public virtual TipoObservacion IdTipoObservacionNavigation { get; set; } = null!;
}
