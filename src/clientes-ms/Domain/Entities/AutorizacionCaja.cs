using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AutorizacionCaja
{
    public long IdAutorizacionCaja { get; set; }

    public string Caja { get; set; } = null!;

    public string NumeroAutorizacion { get; set; } = null!;

    public int? Docini { get; set; }

    public int? Docfin { get; set; }

    public DateTime? Fecini { get; set; }

    public DateTime? Fecfin { get; set; }

    public string? Numero { get; set; }

    public string? Estado { get; set; }

    public string? NumEstablecimiento { get; set; }

    public int IdLocal { get; set; }

    public string? Direccion { get; set; }

    public string? Ruc { get; set; }

    public string? NombreComercial { get; set; }

    public long IdEmpresa { get; set; }

    public bool GenerarXml { get; set; }

    public long? IdTipoDocumento { get; set; }

    public string? Sucursal { get; set; }

    public int? Produccion { get; set; }

    public virtual ICollection<AutorizacionCajaUsuario> AutorizacionCajaUsuario { get; set; } = new List<AutorizacionCajaUsuario>();

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual Locales IdLocalNavigation { get; set; } = null!;

    public virtual TipoDocumentoSri? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Nota> Nota { get; set; } = new List<Nota>();
}
