using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpMaeEmpHistorialBanco
{
    public long IdHistorialBanco { get; set; }

    public long IdEmpleado { get; set; }

    public string? Codcuenta { get; set; }

    public long? Codban { get; set; }

    public string? Ctacte { get; set; }

    public long? IdFormaPago { get; set; }

    public long? CodBanTercero { get; set; }

    public DateOnly FechaDesde { get; set; }

    public DateOnly? FechaHasta { get; set; }

    public int? IdCuentaBanco { get; set; }

    public virtual RpBanTercero? CodBanTerceroNavigation { get; set; }

    public virtual RpBancos? CodbanNavigation { get; set; }

    public virtual TipoCuentaBanco? IdCuentaBancoNavigation { get; set; }

    public virtual RpMaeEmp IdEmpleadoNavigation { get; set; } = null!;

    public virtual RpFomaPago? IdFormaPagoNavigation { get; set; }
}
