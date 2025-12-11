using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Anticipo
{
    public long IdAnticipo { get; set; }

    public string Caja { get; set; } = null!;

    public string? Responsable { get; set; }

    public DateTime? Fecha { get; set; }

    public long? ClientesCodigo { get; set; }

    public double? Monto { get; set; }

    public string? Concepto { get; set; }

    public int? IdLocal { get; set; }

    public double? ValorOriginal { get; set; }

    public DateTime? Fecmod { get; set; }

    public bool Cancelado { get; set; }

    public long? IdFormaPago { get; set; }

    public string? DescripcionFormaPago { get; set; }

    public long? IdBancosTerceros { get; set; }

    public string? NroCuenta { get; set; }

    public string? NroCheque { get; set; }

    public string? Propietario { get; set; }

    public string? NroDocumento { get; set; }

    public string? Nombre { get; set; }

    public string? Autorizacion { get; set; }

    public long? AteNumeroAtencion { get; set; }

    public long? PacHistoriaClinica { get; set; }

    public bool? Arqueada { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public string? UsuarioIngreso { get; set; }

    public DateTime? FechaAnula { get; set; }

    public string? UsuarioAnula { get; set; }

    public int? IdPlazoTarjeta { get; set; }

    public bool? Estado { get; set; }

    public string? Numdoc { get; set; }

    public string? Consec { get; set; }

    public string? Numpag { get; set; }

    public long NumLiquidacion { get; set; }

    public double? AsientoContable { get; set; }

    public string? TipoAsiento { get; set; }

    public double? AsientoContableDev { get; set; }

    public string? TipoAsientoDev { get; set; }

    public int IdTipoAnticipo { get; set; }

    public string? Lote { get; set; }

    public virtual ICollection<AnticipoLiquida> AnticipoLiquida { get; set; } = new List<AnticipoLiquida>();

    public virtual Clientes? ClientesCodigoNavigation { get; set; }

    public virtual BancosTerceros? IdBancosTercerosNavigation { get; set; }

    public virtual FormaPago? IdFormaPagoNavigation { get; set; }

    public virtual Locales? IdLocalNavigation { get; set; }

    public virtual PlazoTarjeta? IdPlazoTarjetaNavigation { get; set; }

    public virtual TipoAnticipo IdTipoAnticipoNavigation { get; set; } = null!;
}
