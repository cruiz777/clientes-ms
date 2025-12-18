using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FechasControl
{
    public long IdFechaControl { get; set; }

    public string FecVal { get; set; } = null!;

    public string TipDoc { get; set; } = null!;

    public string? VarVal { get; set; }

    public short? Dias { get; set; }

    public double? NumDoc { get; set; }

    public string? TipoCon { get; set; }

    public string? Fecha { get; set; }

    public bool Ocupado { get; set; }

    public long IdTipoAsiento { get; set; }

    public long IdEmpresa { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual TipoAsiento IdTipoAsientoNavigation { get; set; } = null!;
}
