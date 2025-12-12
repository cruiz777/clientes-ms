using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PlanificacionPagos
{
    public long IdPlanificacion { get; set; }

    public long? Idcxp { get; set; }

    public double? CodigoC { get; set; }

    public DateOnly? Fecha { get; set; }

    public DateOnly? FechaVenc { get; set; }

    public string? CuentaBanco { get; set; }

    public double? CodForPag { get; set; }

    public long NumTransaccion { get; set; }

    public string? Comentario { get; set; }

    public double ValorPago { get; set; }

    public string? EstadoPago { get; set; }

    public double UsuarioIng { get; set; }

    public string Estado { get; set; } = null!;

    public int EstadoPlanificacion { get; set; }

    public double TotalPagoPlanilla { get; set; }

    public double? UsuarioAprueba { get; set; }

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

    public string? Observacionasiento { get; set; }

    public long? IdEmpresa { get; set; }
}
