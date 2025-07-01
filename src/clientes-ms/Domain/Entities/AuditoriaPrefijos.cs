using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AuditoriaPrefijos
{
    public long Id { get; set; }

    public string? Codpre { get; set; }

    public string? Usuario { get; set; }

    public string? Fecha { get; set; }

    public string? Empresa { get; set; }

    public string? Ruc { get; set; }
}
