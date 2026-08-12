using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class GastosSri
{
    public long IdGasSri { get; set; }

    public int IdEmpresa { get; set; }

    public int IdTipoGasto { get; set; }

    public decimal? MontoProyectado { get; set; }

    public decimal? MontoReal { get; set; }

    public long? IdEmpleado { get; set; }

    public virtual RpMaeEmp? IdEmpleadoNavigation { get; set; }

    public virtual TipoGasto IdTipoGastoNavigation { get; set; } = null!;
}
