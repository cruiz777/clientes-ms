using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class FormaPagoCg
{
    public long IdFormaPagoCg { get; set; }

    public long IdEmpresa { get; set; }

    public string? Descripcion { get; set; }

    public bool Activo { get; set; }

    public int AplicaPlanPagos { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<PlanificacionPagos> PlanificacionPagos { get; set; } = new List<PlanificacionPagos>();
}
