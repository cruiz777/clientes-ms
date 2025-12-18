using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Bancos
{
    public long IdBanco { get; set; }

    public string? Descripcion { get; set; }

    public string? CodigoEspecial { get; set; }

    public long IdEmpresa { get; set; }

    public virtual ICollection<BancosEmpresa> BancosEmpresa { get; set; } = new List<BancosEmpresa>();

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;
}
