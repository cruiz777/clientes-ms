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

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual ICollection<Contadores> Contadores { get; set; } = new List<Contadores>();

    public virtual ICollection<Departamentos> Departamentos { get; set; } = new List<Departamentos>();

    public virtual ICollection<EstadoEmpresa> EstadoEmpresa { get; set; } = new List<EstadoEmpresa>();

    public virtual ICollection<Gerentes> Gerentes { get; set; } = new List<Gerentes>();

    public virtual Ciudades IdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Perfiles> Perfiles { get; set; } = new List<Perfiles>();

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<TipoCliente> TipoCliente { get; set; } = new List<TipoCliente>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    public virtual ICollection<Vendedor> Vendedor { get; set; } = new List<Vendedor>();

    public virtual ICollection<Zona> Zona { get; set; } = new List<Zona>();
}
