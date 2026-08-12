using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Departamentos
{
    public long IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public string? Cuenta { get; set; }

    public long? IdEmpresa { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ActivoFijo> ActivoFijo { get; set; } = new List<ActivoFijo>();

    public virtual Empresas? IdEmpresaNavigation { get; set; }

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
