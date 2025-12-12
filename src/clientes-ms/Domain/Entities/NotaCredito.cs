using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NotaCredito
{
    public long IdNotaCredito { get; set; }

    public string Numnota { get; set; } = null!;

    public string Id { get; set; } = null!;

    public string? Caja { get; set; }

    public double? Valor { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Numdoc { get; set; }

    public string? Codusu { get; set; }

    public long? ClientesCodigo { get; set; }

    public double? Valoranterior { get; set; }

    public bool Cancelado { get; set; }

    public string? Obs { get; set; }

    public DateTime? Fechafac { get; set; }

    public DateTime? Fecmod { get; set; }

    public string? Codcue { get; set; }

    public bool? Iva { get; set; }

    public double Neto { get; set; }

    public double Descuento { get; set; }

    public double Subtotal { get; set; }

    public double Totsiva { get; set; }

    public double Totciva { get; set; }

    public double Valoriva { get; set; }

    public double Total { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public string? UsuarioIngreso { get; set; }

    public DateTime? FechaAnula { get; set; }

    public string? UsuarioAnula { get; set; }

    public string? Asicon { get; set; }

    public int TipoNotaCredito { get; set; }

    public int Tipond { get; set; }

    public string? Establecimiento { get; set; }

    public string? Rucproveedor { get; set; }

    public string? Proveedor { get; set; }

    public string? Codcuehaber { get; set; }

    public bool? Arqueada { get; set; }

    public string? Consec { get; set; }

    public int AteCodigo { get; set; }

    public string? HistoriaClinica { get; set; }

    public string? ClaveAcceso { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }

    public virtual ICollection<DetalleNotaCredito> DetalleNotaCredito { get; set; } = new List<DetalleNotaCredito>();

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual ICollection<PagosNotaCredito> PagosNotaCredito { get; set; } = new List<PagosNotaCredito>();
}
