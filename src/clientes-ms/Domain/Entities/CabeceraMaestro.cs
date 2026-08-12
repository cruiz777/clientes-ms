using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CabeceraMaestro
{
    public long IdCabMaestro { get; set; }

    public long IdZona { get; set; }

    public long IdUsuario { get; set; }

    public long IdEmpresa { get; set; }

    public long IdTipoAsiento { get; set; }

    public string Tipdoc { get; set; } = null!;

    public double Numdoc { get; set; }

    public string Anio { get; set; } = null!;

    public DateTime Fechatransaccion { get; set; }

    public DateTime Fechaingreso { get; set; }

    public string? Observacion { get; set; }

    public double? Totdebe { get; set; }

    public double? Tothaber { get; set; }

    public string? Beneficiario { get; set; }

    public string? Cierre { get; set; }

    public DateTime? Fechacierre { get; set; }

    public string? Solicitado { get; set; }

    public string? Depto { get; set; }

    public string? Autorizado { get; set; }

    public long HomCodigo { get; set; }

    public bool Estado { get; set; }

    public int Modulo { get; set; }

    public virtual ICollection<CabeceraLiquidacion> CabeceraLiquidacion { get; set; } = new List<CabeceraLiquidacion>();

    public virtual ICollection<CuentasPorPagar> CuentasPorPagar { get; set; } = new List<CuentasPorPagar>();

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual TipoAsiento IdTipoAsientoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual Zona IdZonaNavigation { get; set; } = null!;

    public virtual ICollection<Retenciones> Retenciones { get; set; } = new List<Retenciones>();
}
