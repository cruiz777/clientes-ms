using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Clientes
{
    public long ClientesCodigo { get; set; }

    public string? Nomcli { get; set; }

    public string? Dircli { get; set; }

    public string? Concli { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Telefono1 { get; set; }

    public string? RazonSocial { get; set; }

    public string? Fax { get; set; }

    public string? Ruc { get; set; }

    public DateOnly? Fecing { get; set; }

    public DateOnly? Fecnac { get; set; }

    public DateOnly? FechaCeseAct { get; set; }

    public string? MotivoCeseAct { get; set; }

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

    public DateTime? Fechtre { get; set; }

    public string? Web { get; set; }

    public decimal? Saldo { get; set; }

    public string? Fecfac { get; set; }

    public string? Ciudad { get; set; }

    public string? Obs { get; set; }

    public short? Delestado { get; set; }

    public string? Genero { get; set; }

    public string? Infcamahabitacion { get; set; }

    public long? EmpresaCodigo { get; set; }

    public short? Seguimiento { get; set; }

    public DateOnly? Fechaactinact { get; set; }

    public long? IdEstadoEmpresa { get; set; }

    public int? Formatodocumento { get; set; }

    public int? Imprimeobstramite { get; set; }

    public long? IdTipoCliente { get; set; }

    public long? IdGrupoProducto { get; set; }

    public long? IdPersona { get; set; }

    public string? CodigoPostal { get; set; }

    public string? CodigoPostal2 { get; set; }

    public long? IdVendedor { get; set; }

    public long? IdCiudad { get; set; }

    public long? IdZona { get; set; }

    public long? IdGrupoEmpresa { get; set; }

    public string? Representante { get; set; }

    public DateOnly? Fecmod { get; set; }

    public string? Usumod { get; set; }

    public virtual ICollection<AuditoriaTransferencia> AuditoriaTransferenciaClientesCodigoDestinoNavigation { get; set; } = new List<AuditoriaTransferencia>();

    public virtual ICollection<AuditoriaTransferencia> AuditoriaTransferenciaClientesCodigoOrigenNavigation { get; set; } = new List<AuditoriaTransferencia>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }

    public virtual ICollection<Gln> Gln { get; set; } = new List<Gln>();

    public virtual ICollection<HistorialCliente> HistorialCliente { get; set; } = new List<HistorialCliente>();

    public virtual Ciudades? IdCiudadNavigation { get; set; }

    public virtual EstadoEmpresa? IdEstadoEmpresaNavigation { get; set; }

    public virtual GrupoEmpresa? IdGrupoEmpresaNavigation { get; set; }

    public virtual GrupoProducto? IdGrupoProductoNavigation { get; set; }

    public virtual TipoCliente? IdTipoClienteNavigation { get; set; }

    public virtual Vendedor? IdVendedorNavigation { get; set; }

    public virtual Zona? IdZonaNavigation { get; set; }

    public virtual ICollection<Prefijos> Prefijos { get; set; } = new List<Prefijos>();

    public virtual ICollection<TipoEmpresaLocalizacion> TipoEmpresaLocalizacion { get; set; } = new List<TipoEmpresaLocalizacion>();
}
