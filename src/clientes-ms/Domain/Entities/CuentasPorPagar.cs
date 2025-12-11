using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CuentasPorPagar
{
    public long IdCuentaPorPagar { get; set; }

    public long IdEmpresa { get; set; }

    public long IdUsuario { get; set; }

    public long IdFormaPagoCg { get; set; }

    public long IdCodContable { get; set; }

    public long IdCabMaestro { get; set; }

    public string? TipMov { get; set; }

    public string? Tipasi { get; set; }

    public double Numasi { get; set; }

    public DateOnly? Fechatran { get; set; }

    public DateTime? Fechaing { get; set; }

    public string Nocomp { get; set; } = null!;

    public string? Numdoc { get; set; }

    public DateOnly? FechaVenc { get; set; }

    public long IdPlanCuentas { get; set; }

    public string? Ctacble { get; set; }

    public double Debe { get; set; }

    public double Haber { get; set; }

    public string? Estado { get; set; }

    public string? Comentario { get; set; }

    public double? Numlinea { get; set; }

    public string? Estadopago { get; set; }

    public double? Saldo { get; set; }

    public DateOnly? FechaModif { get; set; }

    public double? Usuariomodif { get; set; }

    public string? CuentaBanco { get; set; }

    public double? CodForPag { get; set; }

    public long NumTransaccion { get; set; }

    public double ValorPago { get; set; }

    public int Forpag { get; set; }

    public int Pago { get; set; }

    public string? Despag { get; set; }

    public double? Comisiontar { get; set; }

    public double? SaldoCxP { get; set; }

    public long HomCodigo { get; set; }

    public virtual CabeceraMaestro IdCabMaestroNavigation { get; set; } = null!;

    public virtual CodigosContables IdCodContableNavigation { get; set; } = null!;

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual FormaPagoCg IdFormaPagoCgNavigation { get; set; } = null!;

    public virtual PlanCuentas IdPlanCuentasNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
