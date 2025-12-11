using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Locales
{
    public int IdLocal { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Telefono3 { get; set; }

    public double? Area { get; set; }

    public string? LocalRuc { get; set; }

    public string? Administrador { get; set; }

    public string? Fax { get; set; }

    public int? NumeroEmpleados { get; set; }

    public bool? LocalBodega { get; set; }

    public bool? Principal { get; set; }

    public bool? Priopridad { get; set; }

    public int? ProcentejeDis { get; set; }

    public bool? LocalHis { get; set; }

    public long IdZona { get; set; }

    public long IdTipoNegocio { get; set; }

    public long? IdCiudad { get; set; }

    public long IdCentroCostos { get; set; }

    public long IdEmpresa { get; set; }

    public bool Estado { get; set; }

    public bool? AplicaPedido { get; set; }

    public string? DirIpBodega { get; set; }

    public int? Bstock { get; set; }

    public bool? BodPedidoP { get; set; }

    public bool? BodDespachoP { get; set; }

    public string? BodUbicacion { get; set; }

    public virtual ICollection<Anticipo> Anticipo { get; set; } = new List<Anticipo>();

    public virtual ICollection<AutorizacionCaja> AutorizacionCaja { get; set; } = new List<AutorizacionCaja>();

    public virtual ICollection<Bodega> Bodega { get; set; } = new List<Bodega>();

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual CentroCostos IdCentroCostosNavigation { get; set; } = null!;

    public virtual Ciudades? IdCiudadNavigation { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual TipoNegocio IdTipoNegocioNavigation { get; set; } = null!;

    public virtual ICollection<ProductoUbicacionBodega> ProductoUbicacionBodega { get; set; } = new List<ProductoUbicacionBodega>();

    public virtual ICollection<Stocks> Stocks { get; set; } = new List<Stocks>();
}
