using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class GrupoEmpresa
{
    public long IdGrupoEmpresa { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public double? Inscripcion { get; set; }

    public double? Asignacion { get; set; }

    public double? Mantenimiento { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? ProductoInscripcion { get; set; }

    public string? ProductoMantenimiento { get; set; }

    public string? ProductoAsignacion { get; set; }

    public double? AsignacionDolar { get; set; }

    public double? MantenimientoDolar { get; set; }

    public double? InscripcionDolar { get; set; }

    public double? ValorAnual { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
}
