using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Clientes
{
    public long ClientesCodigo { get; set; }

    public long? IdVendedor { get; set; }

    public long? CiudadCodigo { get; set; }

    public long? IdZona { get; set; }

    public long? IdDatosAdicionales { get; set; }

    public long? IdGrupoEmpresa { get; set; }

    public string? SicClientesRazonSocial { get; set; }

    public string? SicClientesRazonNombreComercial { get; set; }

    public string? SicClientesDireccion { get; set; }

    public string? SicClientesTelefono { get; set; }

    public string? Telefono1 { get; set; }

    public string? Fax { get; set; }

    public string? Ruc { get; set; }

    public long? IdContactosClientes { get; set; }

    public DateOnly? Fecing { get; set; }

    public DateOnly? Fecnac { get; set; }

    public DateOnly? Fecfac1 { get; set; }

    public DateOnly? Fecfac2 { get; set; }

    public DateOnly? Fecfac3 { get; set; }

    public DateOnly? Fecfac4 { get; set; }

    public DateOnly? Fecfac5 { get; set; }

    public string? Marca1 { get; set; }

    public string? Marca2 { get; set; }

    public string? Marca3 { get; set; }

    public string? Marca4 { get; set; }

    public string? Marca5 { get; set; }

    public string? Codcue { get; set; }

    public string? Hello { get; set; }

    public double? Desde { get; set; }

    public byte[]? Fechtre { get; set; }

    public decimal? Saldo { get; set; }

    public string? Fecfac { get; set; }

    public string? Ciudad { get; set; }

    public string? Obs { get; set; }

    public short? Delestado { get; set; }

    public string? Genero { get; set; }

    public string? Infcamahabitacion { get; set; }

    public long? Empid { get; set; }

    public string? Tiprep { get; set; }

    public short? Seguimiento { get; set; }

    public DateOnly? Fechaactinact { get; set; }

    public short? Estado { get; set; }

    public long? IdEstadoEmpresaCodigo { get; set; }

    public int? Formatodocumento { get; set; }

    public int? Imprimeobstramite { get; set; }

    public long? IdTipoCliente { get; set; }

    public long? IdGrupoProducto { get; set; }

    public long? TipoOrigenIngresos { get; set; }

    public long? IdPersona { get; set; }

    public long? EmpresaCodigo { get; set; }

    public virtual Ciudades? CiudadCodigoNavigation { get; set; }

    public virtual ICollection<ContactosClientes> ContactosClientes { get; set; } = new List<ContactosClientes>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }

    public virtual DatosAdicionales? IdDatosAdicionalesNavigation { get; set; }

    public virtual EstadoEmpresa? IdEstadoEmpresaCodigoNavigation { get; set; }

    public virtual GrupoEmpresa? IdGrupoEmpresaNavigation { get; set; }

    public virtual GrupoProducto? IdGrupoProductoNavigation { get; set; }

    public virtual Personas? IdPersonaNavigation { get; set; }

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }

    public virtual Zona? IdZonaNavigation { get; set; }

    public virtual ICollection<Prefijos> Prefijos { get; set; } = new List<Prefijos>();

    public virtual ICollection<TipoEmpresaLocalizacion> TipoEmpresaLocalizacion { get; set; } = new List<TipoEmpresaLocalizacion>();

    public virtual TipoOrigenIngresos? TipoOrigenIngresosNavigation { get; set; }
}
