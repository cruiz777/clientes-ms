using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class PlanCuentas
{
    public string CuentaPrincipal { get; set; } = null!;

    public string CuentaMayor { get; set; } = null!;

    public string CuentaSubcta { get; set; } = null!;

    public string? CuentaPresentacion { get; set; }

    public string? NombreCuenta { get; set; }

    public long? IdCodigoEspecial { get; set; }

    public long IdNivel { get; set; }

    public string? Descripcion { get; set; }

    public string? CuentaHomologacion { get; set; }

    public double? PorcentajeRetencion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaActivacion { get; set; }

    public long IdUsuario { get; set; }

    public long? IdCabModelo { get; set; }

    public long? ParentId { get; set; }

    public bool? EsMovimiento { get; set; }

    public int? Orden { get; set; }

    public string? CuentaDetalle { get; set; }

    public string? CodigoCompleto { get; set; }

    public long IdPlanCuentas { get; set; }

    public string? CodigoExterno { get; set; }

    public string? Norma { get; set; }

    public string? Alcanse { get; set; }

    public string? Medicion { get; set; }

    public long IdEmpresa { get; set; }

    public string? Numerocuenta { get; set; }

    public string? Formato { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijoIdPlanCuentas1Navigation { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdPlanCuentas2Navigation { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdPlanCuentas4Navigation { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdPlanCuentas5Navigation { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<ActivoFijo> ActivoFijoIdPlanCuentasNavigation { get; set; } = new List<ActivoFijo>();

    public virtual ICollection<CabeceraConciliacion> CabeceraConciliacion { get; set; } = new List<CabeceraConciliacion>();

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<DetalleActivoFijo> DetalleActivoFijo { get; set; } = new List<DetalleActivoFijo>();

    public virtual ICollection<DetalleLiquidacion> DetalleLiquidacion { get; set; } = new List<DetalleLiquidacion>();

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual ICollection<FormaPago> FormaPago { get; set; } = new List<FormaPago>();

    public virtual CabeceraModelo? IdCabModeloNavigation { get; set; }

    public virtual CodigosEspeciales? IdCodigoEspecialNavigation { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual NivelPlanCuentas IdNivelNavigation { get; set; } = null!;

    public virtual ICollection<NumeroCheques> NumeroCheques { get; set; } = new List<NumeroCheques>();

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
