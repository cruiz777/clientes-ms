using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AnticipoLiquida
{
    public long IdAnticipoLiquida { get; set; }

    public long NumLiquidacion { get; set; }

    public DateOnly? FechaLiquidacion { get; set; }

    public long IdAnticipo { get; set; }

    public string? Responsable { get; set; }

    public long? ClientesCodigo { get; set; }

    public double? ValorLiquidado { get; set; }

    public string? Concepto { get; set; }

    public long? IdFormaPago { get; set; }

    public double? AsientoContable { get; set; }

    public string? TipoAsiento { get; set; }

    public string? CodBeneficiario { get; set; }

    public string? Beneficiario { get; set; }

    public string? TipoPago { get; set; }

    public string? TipoCuenta { get; set; }

    public string? NroCuenta { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Cedula { get; set; }

    public string? CtaBanco { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public string? UsuarioIngreso { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }

    public virtual Anticipo IdAnticipoNavigation { get; set; } = null!;

    public virtual FormaPago? IdFormaPagoNavigation { get; set; }
}
