using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class CentroCostos
{
    public long IdCentroCostos { get; set; }

    public string? Descripcion { get; set; }

    public string? Cuenta { get; set; }

    public long IdEmpresa { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<DetalleMaestro> DetalleMaestro { get; set; } = new List<DetalleMaestro>();

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<Locales> Locales { get; set; } = new List<Locales>();
}
