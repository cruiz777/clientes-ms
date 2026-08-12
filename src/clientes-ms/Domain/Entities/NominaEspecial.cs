using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NominaEspecial
{
    public long IdNominaEspecial { get; set; }

    public int? IdLocal { get; set; }

    public long? IdEmpleado { get; set; }

    public string? Periodo { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public string? Identificacion { get; set; }

    public string? NumeroAfiliado { get; set; }

    public string? CodigoSectorial { get; set; }

    public string? NumeroDias { get; set; }

    public double? Valor { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public string? Observacion { get; set; }

    public DateOnly? FechaEmision { get; set; }

    public long? IdUsuario { get; set; }

    public double? ValorAcum { get; set; }

    public int? Cargas { get; set; }

    public double? ValCargas { get; set; }

    public bool? UtilidadesConyugue { get; set; }

    public double? ValTotal1 { get; set; }

    public double? ValTotal2 { get; set; }

    public long? IdBancos { get; set; }

    public double? Descuentos { get; set; }

    public double? PagoD3 { get; set; }

    public double? PagoD4 { get; set; }

    public double? PretJudi { get; set; }

    public string? TipoSectorial { get; set; }

    public int? IdTipoNomEsp { get; set; }

    public virtual RpBancos? IdBancosNavigation { get; set; }

    public virtual RpMaeEmp? IdEmpleadoNavigation { get; set; }

    public virtual TipoNominaEsp? IdTipoNomEspNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
