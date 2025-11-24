using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FacturaPago
{
    public long IdFacturaPago { get; set; }

    public long IdFormaPago { get; set; }

    public string Numnota { get; set; } = null!;

    public double Tipdoc { get; set; }

    public string? Tipomov { get; set; }

    public string? Codcli { get; set; }

    public string? Parcial { get; set; }

    public string? Parcial1 { get; set; }

    public string? Claspag { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Fecha1 { get; set; }

    public string? Banco { get; set; }

    public string? NumcuentaTarj { get; set; }

    public string? ChequeCaduca { get; set; }

    public string? Duenio { get; set; }

    public string? Autoriza { get; set; }

    public string? Obs { get; set; }

    public double Fila { get; set; }

    public string? Caja { get; set; }

    public string? Cajero { get; set; }

    public string? Vendedor { get; set; }

    public string? Local { get; set; }

    public bool? Arqueada { get; set; }

    public bool? Imprime { get; set; }

    public bool? Detalle { get; set; }

    public string? CodPlazo { get; set; }

    public string? Consec { get; set; }

    public double? AsientoContable { get; set; }

    public string? TipoAsiento { get; set; }

    public virtual FormaPago IdFormaPagoNavigation { get; set; } = null!;

    public virtual Nota NumnotaNavigation { get; set; } = null!;
}
