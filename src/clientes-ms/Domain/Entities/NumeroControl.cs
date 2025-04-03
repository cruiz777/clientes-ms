using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NumeroControl
{
    public long IdNumeroControl { get; set; }

    public double? Codcon { get; set; }

    public string? Modcon { get; set; }

    public string? Tipcon { get; set; }

    public string? Numcon { get; set; }

    public bool? Ocupado { get; set; }

    public long? EmpresaCodigo { get; set; }
}
