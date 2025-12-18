using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class NumeroControlCg
{
    public long IdNumeroControl { get; set; }

    public int Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public long Secuencial { get; set; }

    public string? Nestablecimiento { get; set; }

    public string? PuntoEmision { get; set; }

    public bool? Ocupado { get; set; }

    public long IdEmpresa { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;
}
