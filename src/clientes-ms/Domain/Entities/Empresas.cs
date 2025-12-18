using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Empresas
{
    public long IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Sistema { get; set; }

    public string? Ruc { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Logo { get; set; }

    public string? Firma { get; set; }

    public string? Moneda { get; set; }

    public string? TipoCambio { get; set; }

    public string? Establecimiento { get; set; }

    public string? TipoFacturacion { get; set; }

    public string? ContribuyenteEspecial { get; set; }

    public string ObligadoContabilidad { get; set; } = null!;

    public string? CodigoEntidad { get; set; }

    public string? Directorio { get; set; }

    public bool Status { get; set; }

    public long IdCiudad { get; set; }

    public virtual ICollection<AutorizacionCaja> AutorizacionCaja { get; set; } = new List<AutorizacionCaja>();

    public virtual ICollection<Bancos> Bancos { get; set; } = new List<Bancos>();

    public virtual ICollection<BancosEmpresa> BancosEmpresa { get; set; } = new List<BancosEmpresa>();

    public virtual ICollection<CabeceraMaestro> CabeceraMaestro { get; set; } = new List<CabeceraMaestro>();

    public virtual ICollection<CentroCostos> CentroCostos { get; set; } = new List<CentroCostos>();

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual ICollection<CodigosContables> CodigosContables { get; set; } = new List<CodigosContables>();

    public virtual ICollection<Contadores> Contadores { get; set; } = new List<Contadores>();

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<Departamentos> Departamentos { get; set; } = new List<Departamentos>();

    public virtual ICollection<EstadoEmpresa> EstadoEmpresa { get; set; } = new List<EstadoEmpresa>();

    public virtual ICollection<EstructuraComercial> EstructuraComercial { get; set; } = new List<EstructuraComercial>();

    public virtual ICollection<FechasControl> FechasControl { get; set; } = new List<FechasControl>();

    public virtual ICollection<FormaPago> FormaPago { get; set; } = new List<FormaPago>();

    public virtual ICollection<FormaPagoCg> FormaPagoCg { get; set; } = new List<FormaPagoCg>();

    public virtual ICollection<Gerentes> Gerentes { get; set; } = new List<Gerentes>();

    public virtual ICollection<HistorialCliente> HistorialCliente { get; set; } = new List<HistorialCliente>();

    public virtual Ciudades IdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Locales> Locales { get; set; } = new List<Locales>();

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();

    public virtual ICollection<NotaCredito> NotaCredito { get; set; } = new List<NotaCredito>();

    public virtual ICollection<NumeroCheques> NumeroCheques { get; set; } = new List<NumeroCheques>();

    public virtual ICollection<NumeroControlCg> NumeroControlCg { get; set; } = new List<NumeroControlCg>();

    public virtual ICollection<ParametrosSic> ParametrosSic { get; set; } = new List<ParametrosSic>();

    public virtual ICollection<Perfiles> Perfiles { get; set; } = new List<Perfiles>();

    public virtual ICollection<PlanCuentas> PlanCuentas { get; set; } = new List<PlanCuentas>();

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<ProductoGrupo> ProductoGrupo { get; set; } = new List<ProductoGrupo>();

    public virtual ICollection<Proyectos> Proyectos { get; set; } = new List<Proyectos>();

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();

    public virtual ICollection<TipoCliente> TipoCliente { get; set; } = new List<TipoCliente>();

    public virtual ICollection<TipoNegocio> TipoNegocio { get; set; } = new List<TipoNegocio>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    public virtual ICollection<Vendedor> Vendedor { get; set; } = new List<Vendedor>();

    public virtual ICollection<Zona> Zona { get; set; } = new List<Zona>();
}
