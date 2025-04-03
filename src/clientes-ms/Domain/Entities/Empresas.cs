using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Empresas
{
    public long EmpresaCodigo { get; set; }

    public string? EmpresaNombre { get; set; }

    public string? EmpresaSistema { get; set; }

    public string? EmpresaRuc { get; set; }

    public string? EmpresaDireccion { get; set; }

    public string? EmpresaTelefono1 { get; set; }

    public string? EmpresaTelefono2 { get; set; }

    public string? EmpresaFax { get; set; }

    public string? EmpresaEmail { get; set; }

    public string? EmpresaGerente { get; set; }

    public string? EmpresaCedulaGerente { get; set; }

    public string? EmpresaDireccionGerente { get; set; }

    public string? EmpresaNombreContador { get; set; }

    public string? EmpresaTelefonoGerente { get; set; }

    public string? EmpresaRegistroContador { get; set; }

    public string? EmpresaTelefonoContador { get; set; }

    public string? EmpresaDireccionContador { get; set; }

    public string? EmpresaCedulaContador { get; set; }

    public string? EmpresaLogo { get; set; }

    public string? EmpresaMoneda { get; set; }

    public string? EmpresaTipoCambio { get; set; }

    public string? EmpresaEstablecimiento { get; set; }

    public string? EmpresaTipoFacturacion { get; set; }

    public string? EmpresaContribuyenteEspecial { get; set; }

    public string EmpresaObligadoContabilidad { get; set; } = null!;

    public string? EmpresaCodigoEntidad { get; set; }

    public string? EmpresaDirectorio { get; set; }

    public bool Status { get; set; }

    public long IdCiudad { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual ICollection<EstadoEmpresa> EstadoEmpresa { get; set; } = new List<EstadoEmpresa>();

    public virtual Ciudades IdCiudadNavigation { get; set; } = null!;

    public virtual ICollection<Perfiles> Perfiles { get; set; } = new List<Perfiles>();

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();

    public virtual ICollection<TipoCliente> TipoCliente { get; set; } = new List<TipoCliente>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();

    public virtual ICollection<Vendedor> Vendedor { get; set; } = new List<Vendedor>();

    public virtual ICollection<Zona> Zona { get; set; } = new List<Zona>();
}
