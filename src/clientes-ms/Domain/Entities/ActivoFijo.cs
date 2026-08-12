using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ActivoFijo
{
    public long CodigoAf { get; set; }

    public string? Codigobarra { get; set; }

    public long? IdPlanCuentas { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public long? IdMarca { get; set; }

    public DateOnly? Feccompra { get; set; }

    public double? Vidautil { get; set; }

    public string? Model { get; set; }

    public string? Serie { get; set; }

    public double? Valorcompra { get; set; }

    public double? Valorresidual { get; set; }

    public double? Tipcod { get; set; }

    public string? Destipcod { get; set; }

    public double? Local { get; set; }

    public string? Comprobante { get; set; }

    public string? Observacion { get; set; }

    public string? Color { get; set; }

    public string? Ubicacion { get; set; }

    public string? Custodio { get; set; }

    public int? Tiempodeprec { get; set; }

    public long? IdPlanCuentas1 { get; set; }

    public long? IdPlanCuentas2 { get; set; }

    public long? IdPlanCuentas3 { get; set; }

    public long? IdPlanCuentas4 { get; set; }

    public long? IdPlanCuentas5 { get; set; }

    public int? ValorRazonable { get; set; }

    public int? AjusteIncremento { get; set; }

    public int? VidaUtilTotal { get; set; }

    public int? SaldoVidaUtil { get; set; }

    public double? NvaDepresiacionAnual { get; set; }

    public string? PathImagenActivo { get; set; }

    public string? FechaajusteNiifs { get; set; }

    public double? DepresiacionAnual { get; set; }

    public double? ValorLibros { get; set; }

    public double? PorcentajeDepresiacion { get; set; }

    public double? DepDeducibleSri { get; set; }

    public double? DepNoDeducibleNiifs { get; set; }

    public double? PorcentajeDepreciado { get; set; }

    public double? DepreAcumulada { get; set; }

    public double? DebeCuenta1 { get; set; }

    public double? HaberCuenta1 { get; set; }

    public double? DebeCuenta2 { get; set; }

    public double? HaberCuenta2 { get; set; }

    public double? DebeCuenta3 { get; set; }

    public double? HaberCuenta3 { get; set; }

    public string? Proveedor { get; set; }

    public double? DepresiacionMensual { get; set; }

    public string? ComprobanteDiario { get; set; }

    public double? DepreMensual { get; set; }

    public int? TiempodeprecMes { get; set; }

    public int? TiempodeprecDia { get; set; }

    public string? ComprobanteRet { get; set; }

    public string? Poliza { get; set; }

    public double? Debecuenta4 { get; set; }

    public double? Debecuenta5 { get; set; }

    public double? Habercuenta4 { get; set; }

    public double? Habercuenta5 { get; set; }

    public int? Intangible { get; set; }

    public DateOnly? FechaDepreciacion { get; set; }

    public DateOnly? FechaDeprecia { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public TimeOnly? HoraIngreso { get; set; }

    public long? IdUsuario { get; set; }

    public long? IdEmpresa { get; set; }

    public long? IdDepartamento { get; set; }

    public DateOnly? FechaCompraReal { get; set; }

    public virtual ICollection<DetalleActivoFijo> DetalleActivoFijo { get; set; } = new List<DetalleActivoFijo>();

    public virtual Departamentos? IdDepartamentoNavigation { get; set; }

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual MarcaCg? IdMarcaNavigation { get; set; }

    public virtual PlanCuentas? IdPlanCuentas1Navigation { get; set; }

    public virtual PlanCuentas? IdPlanCuentas2Navigation { get; set; }

    public virtual PlanCuentas? IdPlanCuentas4Navigation { get; set; }

    public virtual PlanCuentas? IdPlanCuentas5Navigation { get; set; }

    public virtual PlanCuentas? IdPlanCuentasNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
