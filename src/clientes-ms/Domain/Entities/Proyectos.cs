using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Proyectos
{
    public long IdProyecto { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public long? IdEmpresa { get; set; }

    public virtual Empresas? IdEmpresaNavigation { get; set; }
}
