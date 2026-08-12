using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class RpCargos
{
    public long IdCargo { get; set; }

    public string Descargo { get; set; } = null!;

    public bool Responsable { get; set; }

    public string? Codsec { get; set; }

    public bool HorEnf { get; set; }

    public bool Frmensual { get; set; }

    public bool Estado { get; set; }

    public long? IdSectorial { get; set; }

    public long IdEmpresa { get; set; }

    public virtual Empresas IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<RpMaeEmp> RpMaeEmp { get; set; } = new List<RpMaeEmp>();
}
