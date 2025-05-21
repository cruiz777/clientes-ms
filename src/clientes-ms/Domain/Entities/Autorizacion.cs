using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Autorizacion
{
    public int Codaut { get; set; }

    public string Caja { get; set; } = null!;

    public string Numaut { get; set; } = null!;

    public int? Docini { get; set; }

    public int? Docfin { get; set; }

    public DateTime? Fecini { get; set; }

    public DateTime? Fecfin { get; set; }

    public int Tipdoc { get; set; }

    public int? Docsri { get; set; }
}
