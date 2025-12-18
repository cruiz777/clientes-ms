using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Cxc
{
    public string Codcli { get; set; } = null!;

    public string Numdoc { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Debe { get; set; }

    public string? Haber { get; set; }

    public string? Saldo { get; set; }

    public string? Fecha1 { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Tipest { get; set; }

    public DateTime? Fecven { get; set; }

    public string Forpag { get; set; } = null!;

    public string? Claspag { get; set; }

    public string? Fecven1 { get; set; }

    public double Fila { get; set; }

    public string? Marca { get; set; }
}
