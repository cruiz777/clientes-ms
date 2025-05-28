using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class ProductoGrupo
{
    public long IdProdGrupo { get; set; }

    public long IdEmpresa { get; set; }

    public string? DescripcionGrupo { get; set; }

    public long? IdSeccion { get; set; }

    public bool? Estado { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ProductoSeccion? IdSeccionNavigation { get; set; }
}
