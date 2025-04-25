using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Prefijos
{
    public long IdPrefijos { get; set; }

    public string Codpre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public DateTime? FechaCierre { get; set; }

    public string? Observacion { get; set; }

    public string? Digitos { get; set; }

    public bool? Estado { get; set; }

    public int? Control { get; set; }

    public int? Ngln { get; set; }

    public int? Bandera { get; set; }

    public string? Facturar { get; set; }

    public string? Codpro { get; set; }

    public string? Nombre { get; set; }

    public string? Fecfac { get; set; }

    public string? ReferenciaInterna { get; set; }

    public string? Prefijosgs1 { get; set; }

    public string? OrigenPrefijo { get; set; }

    public int? Orden { get; set; }

    public long? ClientesCodigo { get; set; }

    public virtual Clientes? ClientesCodigoNavigation { get; set; }
}
