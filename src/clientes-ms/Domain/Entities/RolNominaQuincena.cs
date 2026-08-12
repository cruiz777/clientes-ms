using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RolNominaQuincena
{
    public long IdRolNominaQuincena { get; set; }

    public long IdEmpleado { get; set; }

    public int? IdLocal { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdIngDesc { get; set; }

    public decimal ValorIe { get; set; }

    public decimal CantiIe { get; set; }

    public DateOnly Fecemi { get; set; }

    public long? IdUsuario { get; set; }

    public string Periodo { get; set; } = null!;

    public byte NumeroQuincena { get; set; }

    public bool Estado { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual IngresoDescuentos IdIngDescNavigation { get; set; } = null!;

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
