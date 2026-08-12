using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RubrosFijos
{
    public long IdRubroFijo { get; set; }

    public long IdEmpleado { get; set; }

    public int? IdLocal { get; set; }

    public int IdIngDesc { get; set; }

    public long? IdUsuario { get; set; }

    public decimal ValorIe { get; set; }

    public decimal CantiIe { get; set; }

    public decimal Numcuotas { get; set; }

    public decimal Cuotaspag { get; set; }

    public DateOnly Fecemi { get; set; }

    public string? Obs { get; set; }

    public string? Obs2 { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual IngresoDescuentos IdIngDescNavigation { get; set; } = null!;

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
