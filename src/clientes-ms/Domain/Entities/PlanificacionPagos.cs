using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PlanificacionPagos
{
    public long IdPlanificacion { get; set; }

    public long? IdCuentaPorPagar { get; set; }

    public long? IdCodContable { get; set; }

    public DateOnly? Fecha { get; set; }

    public DateOnly? FechaVenc { get; set; }

    public string? CuentaBanco { get; set; }

    public long? IdFormaPagoCg { get; set; }

    public long NumTransaccion { get; set; }

    public string? Comentario { get; set; }

    public double ValorPago { get; set; }

    public string? EstadoPago { get; set; }

    public long UsuarioIng { get; set; }

    public string Estado { get; set; } = null!;

    public int EstadoPlanificacion { get; set; }

    public double TotalPagoPlanilla { get; set; }

    public long? UsuarioAprueba { get; set; }

    public int? EstadoAprueba { get; set; }

    public DateOnly? FechaAprueba { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public double CodigoProveedor { get; set; }

    public double Total { get; set; }

    public double Comision { get; set; }

    public double Aporte { get; set; }

    public double? Retencion { get; set; }

    public double RetencionIva { get; set; }

    public double Egreso { get; set; }

    public string? Paciente { get; set; }

    public string? ObservacionAsiento { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual CodigosContables? IdCodContableNavigation { get; set; }

    public virtual CuentasPorPagar? IdCuentaPorPagarNavigation { get; set; }

    public virtual FormaPagoCg? IdFormaPagoCgNavigation { get; set; }

    public virtual Usuarios? UsuarioApruebaNavigation { get; set; }

    public virtual Usuarios UsuarioIngNavigation { get; set; } = null!;
}
