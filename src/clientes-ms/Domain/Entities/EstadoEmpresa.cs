using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class EstadoEmpresa
{
    public long IdEstadoEmpresa { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fecha { get; set; }

    public long? EmpresaCodigo { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual Empresas? EmpresaCodigoNavigation { get; set; }
}
