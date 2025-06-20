using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Sscc
{
    public long IdSscc { get; set; }

    public long IdPrefijo { get; set; }

    public long IdCliente { get; set; }

    public byte Indicador { get; set; }

    public string Serial { get; set; } = null!;

    public string DigitoControl { get; set; } = null!;

    public string SsccCompleto { get; set; } = null!;

    public bool? Serie { get; set; }

    public int? SecuenciaInicio { get; set; }

    public int? SecuenciaFin { get; set; }

    public int? TotalGenerado { get; set; }

    public string? ProductoCodificado { get; set; }

    public bool? Estado { get; set; }

    public string? Usuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Clientes IdClienteNavigation { get; set; } = null!;

    public virtual Prefijos IdPrefijoNavigation { get; set; } = null!;
}
