using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class TipoNegocio
{
    public long IdTipoNegocio { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual ICollection<Locales> Locales { get; set; } = new List<Locales>();
}
