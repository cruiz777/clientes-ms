using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NominaProvisiones
{
    public int IdNomProv { get; set; }

    public long? IdEmpleado { get; set; }

    public int? IdLocal { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public int? IdIngresoDesc { get; set; }

    public decimal? ValorIe { get; set; }

    public decimal? CantIe { get; set; }

    public DateTime? FechaEmision { get; set; }

    public long? IdUsuario { get; set; }

    public decimal? CantiTomado { get; set; }

    public decimal? ValorTomado { get; set; }

    public decimal? ValorAdicional { get; set; }

    public decimal? CantiAdicional { get; set; }

    public decimal? ValorAdicionalTomado { get; set; }

    public decimal? CantiAdicionalTomado { get; set; }

    public bool? Estado { get; set; }

    public string? TipoRol { get; set; }

    public int? IdLiquidaciones { get; set; }

    public int? Linea { get; set; }

    public int? Marca { get; set; }

    public string? FilaAdicional { get; set; }

    public string? Proceso { get; set; }

    public virtual IngresoDescuentos? IdIngresoDescNavigation { get; set; }

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
